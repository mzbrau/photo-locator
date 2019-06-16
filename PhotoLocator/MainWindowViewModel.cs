using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Maps.MapControl.WPF;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace PhotoLocator
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        #region private members...

        private int index = 0;
        private string _bingMapsKey;
        private string _filterText;
        private Map _map;
        private PhotoDefinition _selectedPhoto;
        private ICollectionView _photoSource;

        #endregion

        #region constructor...

        public MainWindowViewModel()
        {
            Photos = new ObservableCollection<PhotoDefinition>();
            BingMapsKey = Properties.Settings.Default.BingMaps;
            _photoSource = CollectionViewSource.GetDefaultView(Photos);
            _photoSource.SortDescriptions.Add(new SortDescription("TakenDate", ListSortDirection.Ascending));

            _photoSource.Filter = FilterItems;
        }

        #endregion

        #region IMainWindowViewModel implementation

        public ObservableCollection<PhotoDefinition> Photos { get; }

        public ICollectionView PhotoSource
        {
            get => _photoSource;
        }

        public PhotoDefinition SelectedPhoto
        {
            get => _selectedPhoto;

            set
            {
                if (_selectedPhoto != value)
                {
                    _selectedPhoto = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ApplicationIdCredentialsProvider BingMapsCredentials
        {
            get
            {
                return new ApplicationIdCredentialsProvider(BingMapsKey);
            }
        }

        public string BingMapsKey
        {
            get => _bingMapsKey;

            set
            {
                if (value != _bingMapsKey)
                {
                    _bingMapsKey = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(BingMapsCredentials));
                }
            }
        }

        public string FilterText
        {
            get => _filterText;

            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    NotifyPropertyChanged();
                    PhotoSource.Refresh();
                }
            }
        }

        public void SetControls(Map map)
        {
            _map = map;
        }

        public void OpenFiles()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select images to show",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "jpg",
                Filter = "Images(*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF",
                FilterIndex = 2,
                RestoreDirectory = true,
                Multiselect = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == true)
                LoadPhotos(openFileDialog1.FileNames);
        }

        public void RenameAll()
        {
            var pins = _map.Children.OfType<Pushpin>();
            var renameResults = new List<RenameResult>();

            foreach (var photo in Photos)
            {
                var matchingPin = pins.FirstOrDefault(p => p.Content.ToString() == photo.Index.ToString());


                var newName = photo.Rename((res) => renameResults.Add(res));

                if (matchingPin != null)
                    matchingPin.ToolTip = newName;
            }

            if (renameResults.Any(r => r.Result == RenameResultType.Error))
            {
                MessageBox.Show(BuildResultMessage(renameResults), "Complete with Errors", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(BuildResultMessage(renameResults), "Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void ExportAll()
        {
            var exporter = new CsvExporter();
            exporter.Export(Photos.ToList());
        }

        public void ShowAll()
        {
            ShowAllImagesOnMap();
        }

        public void NavigateToImage()
        {
            ShowImageOnMap();
        }

        public void OpenImage()
        {
            try
            {
                if (SelectedPhoto != null)
                    Process.Start(SelectedPhoto.FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open photo: {ex.Message}");
            }
        }

        public void ShowSettingsIfNoBingMapsKey()
        {
            if (string.IsNullOrEmpty(BingMapsKey))
                ShowSettings();
        }

        public void ShowSettings()
        {
            var settings = new SettingsWindow(BingMapsKey);
            settings.Owner = App.Current.MainWindow;
            settings.ShowDialog();

            BingMapsKey = settings.BingMapsKey;
            Properties.Settings.Default.BingMaps = BingMapsKey;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region private methods...

        private string BuildResultMessage(IEnumerable<RenameResult> results)
        {
            if (results.All(r => r.Result == RenameResultType.Renamed))
                return $"Successfully renamed {results.Count()} photos.";

            if (results.All(r => r.Result != RenameResultType.Error))
                return $"Renaming complete. Renamed {results.Count(r => r.Result == RenameResultType.Renamed)} " +
                    $"while {results.Count(r => r.Result == RenameResultType.NoChange)} required no change";

            return $"Some errors recorded while renaming. {Environment.NewLine}" +
                $"{results.Count(r => r.Result == RenameResultType.Renamed)} renamed successfully. {Environment.NewLine}" +
                $"{results.Count(r => r.Result == RenameResultType.NoChange)} required no change. {Environment.NewLine}" +
                $"{results.Count(r => r.Result == RenameResultType.Error)} photos had errors including: {Environment.NewLine}" +
                $"{string.Join("\r\n", results.Where(r => r.ErrorMessage != null).Select(r => r.ErrorMessage).Distinct())}";
        }

        private void ShowAllImagesOnMap()
        {
            if (Photos.Where(p => p.Location != null).Any())
                _map.SetView(GetBoundingBox(Photos));
        }

        private void ShowImageOnMap()
        {
            if (SelectedPhoto?.Location != null)
                _map.SetView(GetBoundingBox(new[] { SelectedPhoto }));
        }

        private bool FilterItems(object item)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                return true;
            }

            var pic = item as PhotoDefinition;

            if (pic == null)
            {
                return false;
            }

            if (pic.Index.ToString().Contains(FilterText) || 
                pic.Address.ToLower().Contains(FilterText.ToLower()))
            {
                return true;
            }

            return false;
        }

        private void LoadPhotos(IEnumerable<string> fileNames)
        {
            foreach (var filePath in fileNames)
            {
                var photo = new PhotoDefinition(filePath, ++index, BingMapsKey);

                if (!Photos.Any(p => p.FilePath == photo.FilePath))
                {
                    Photos.Add(photo);

                    if (photo.Location != null)
                    {
                        var pin = new Pushpin
                        {
                            Content = photo.Index,
                            ToolTip = photo.FileName,
                            Location = new Location(photo.Location.Latitude, photo.Location.Longitude)
                        };
                        pin.MouseDown += Pin_MouseDown;
                        _map.Children.Add(pin);
                    }
                }
            }

            ShowAllImagesOnMap();
        }

        private LocationRect GetBoundingBox(IEnumerable<PhotoDefinition> photos)
        {
            var lat = photos.Where(s => s.Location != null)
                            .Select(s => s.Location.Latitude);
            double latMin = lat.Min();
            double latMax = lat.Max();

            var lon = photos.Where(s => s.Location != null)
                            .Select(s => s.Location.Longitude);
            double lonMin = lon.Min();
            double lonMax = lon.Max();

            var latMargin = Margin(latMax - latMin);
            var lonMargin = Margin(lonMax - lonMin);

            var topLeft = new Location(latMin - latMargin, lonMin - lonMargin);
            var bottomRight = new Location(latMax + latMargin, lonMax + lonMargin);

            return new LocationRect(topLeft, bottomRight);
        }

        private double Margin(double value)
        {
            if (value == 0)
            {
                return 0.009;
            }

            return value * 0.1;
        }

        private void Pin_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var pin = sender as Pushpin;

            if (pin != null)
            {
                var matchingPhoto = Photos.FirstOrDefault(p => pin.Content.ToString() == p.Index.ToString());

                if (matchingPhoto != null)
                    SelectedPhoto = matchingPhoto;
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation...

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
