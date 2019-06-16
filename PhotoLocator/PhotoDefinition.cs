using BingMapsRESTToolkit;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Globalization;

namespace PhotoLocator
{
    public class PhotoDefinition : INotifyPropertyChanged
    {
        private string _filePath;
        private GeoLocation _location;
        private string _address;
        private int _orientation = 1;
        private DateTime _takenDate;
        private BitmapImage _bitmap;
        private string _bingMapsKey;

        public PhotoDefinition(string path, int index, string bingMapsKey)
        {
            LoadPhoto(path);
            Index = index;
            _bingMapsKey = bingMapsKey;
        }

        public string FileName => Path.GetFileName(FilePath);

        public int Index { get; }

        public string FilePath
        {
            get => _filePath;

            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("FileName");
                }
            }
        }

        public BitmapImage Bitmap
        {
            get => _bitmap;

            set
            {
                if (_bitmap != value)
                {
                    _bitmap = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool HasLocation
        {
            get => Location != null;
        }

        public int Orientation
        {
            get => _orientation;

            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public GeoLocation Location
        {
            get => _location;

            set
            {
                if (_location != value)
                {
                    _location = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("Coordinates");
                }
            }
        }

        public string Coordinates => Location != null ? 
                                        $"{Location.Latitude}, {Location.Longitude}" : 
                                        string.Empty;

        public string Address
        {
            get => _address;

            set
            {
                if (_address != value)
                {
                    _address = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime TakenDate
        {
            get => _takenDate;

            set
            {
                if (_takenDate != value)
                {
                    _takenDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Rename(Action<RenameResult> recordResult)
        {
            var extension = Path.GetExtension(FilePath);
            var newFileName = $"{TakenDate.ToString("yyyy-MM-dd HHmm")} - {RemoveInvalidFileCharacters(Address)}{extension}";
            var filePath = Path.GetDirectoryName(FilePath);
            var newName = Path.Combine(filePath, newFileName);

            if (newName == FilePath)
            {
                recordResult(RenameResult.NoChange());
                return FilePath;
            }

            newName = GetNonConflicting(newName);

            try
            {
                if (newName != FilePath)
                {
                    var originalName = FilePath;
                    FilePath = newName;
                    File.Copy(originalName, newName);
                    File.Delete(originalName);
                    recordResult(RenameResult.Success());
                }
            }
            catch (Exception ex)
            {
                recordResult(RenameResult.Error(ex.Message));
            }

            return Path.GetFileName(newName);
        }

        private string GetNonConflicting(string originalName)
        {
            if (File.Exists(originalName))
            {
                int index = 1;
                string nonConflictName;
                do
                {
                    var fullPathNoExtension = Path.Combine(Path.GetDirectoryName(originalName), Path.GetFileNameWithoutExtension(originalName));
                    nonConflictName = $"{fullPathNoExtension}({index++}){Path.GetExtension(originalName)}";
                } while (File.Exists(nonConflictName));

                originalName = nonConflictName;
            }

            return originalName;
        }

        private string RemoveInvalidFileCharacters(string input)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            var result = input;

            foreach (char c in invalid)
            {
                result = result.Replace(c.ToString(), "");
            }

            return result;
        }

        private void LoadPhoto(string path)
        {
            FilePath = path;
            TakenDate = File.GetCreationTime(path);

            Bitmap = CreateImage(path);

            IReadOnlyList<MetadataExtractor.Directory> meta = ImageMetadataReader.ReadMetadata(path);

            var gps = meta.OfType<GpsDirectory>()
                          .FirstOrDefault();

            var dir = meta.OfType<ExifIfd0Directory>().FirstOrDefault();
            var dateTaken = dir?.Tags?.FirstOrDefault(m => m.Name == "Date/Time");
            if (dateTaken != null)
            {
                DateTime photoTakenDate = DateTime.MinValue;
                if (DateTime.TryParseExact(dateTaken.Description, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out photoTakenDate))
                {
                    TakenDate = photoTakenDate;
                }
                else
                {
                    TakenDate = File.GetCreationTime(path);
                }
            }

            Location = gps?.GetGeoLocation();

            if (Location != null)
            {
                Task reverseGeocode = Task.Factory.StartNew<string>(() =>
                {
                    return GetAddressFromCoodrinates(Location);

                }).ContinueWith((addr) =>
                {
                    Address = addr.Result;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                Address = "Unknown Location";
            }
        }

        private BitmapImage CreateImage(string path)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.DecodePixelWidth = 120;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(path);
            image.Rotation = ShouldFlip(path);
            image.EndInit();
            image.Freeze();

            return image;
        }

        private Rotation ShouldFlip(string path)
        {
            Image image = Image.FromFile(path);

            foreach (var prop in image.PropertyItems)
            {
                if ((prop.Id == 0x0112 || prop.Id == 5029 || prop.Id == 274))
                {
                    var value = (int)prop.Value[0];
                    if (value == 6)
                    {
                        return Rotation.Rotate90;
                    }
                    else if (value == 8)
                    {
                        return Rotation.Rotate270;
                    }
                    else if (value == 3)
                    {
                        return Rotation.Rotate180;
                    }
                }
            }

            image.Dispose();

            return Rotation.Rotate0;
        }

        private string GetAddressFromCoodrinates(GeoLocation location)
        {
            var r = new ReverseGeocodeRequest()
            {
                Point = new Coordinate(location.Latitude, location.Longitude),
                IncludeEntityTypes = new List<EntityType>(){
                    EntityType.Address,
                },
                IncludeNeighborhood = true,
                IncludeIso2 = true,
                BingMapsKey = _bingMapsKey
            };

            var response = r.Execute((rt) =>{}).Result;

            var result = response.ResourceSets.FirstOrDefault();

            if (result != null)
            {
                var firstEntry = result.Resources.OfType<Location>().FirstOrDefault();

                if (firstEntry != null)
                {
                    return firstEntry.Name;
                }
            }

            return "No Address Found";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
