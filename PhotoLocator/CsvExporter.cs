using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace PhotoLocator
{
    class CsvExporter
    {
        private const string Delimiter = ";";

        public void Export(IEnumerable<PhotoDefinition> photos)
        {
            var csv = BuildCsv(photos);
            var fileName = WriteToFile(csv);
            OpenFile(fileName);
        }
    
        private string GetRow(PhotoDefinition photo)
        {
            return $"{photo.FileName}{Delimiter}{photo.Address}{Delimiter}{photo.TakenDate}{Delimiter}{photo.Location?.Latitude}{Delimiter}" +
                   $"{photo.Location?.Longitude}{Delimiter}{photo.FilePath}";
        }

        private string GetHeader()
        {
            return $"Name{Delimiter}Address{Delimiter}Date Taken{Delimiter}Latitude{Delimiter}Longitude{Delimiter}File Path";
        }

        private List<string> BuildCsv(IEnumerable<PhotoDefinition> photos)
        {
            List<string> lines = new List<string>();
            lines.Add(GetHeader());
            foreach (var photo in photos)
            {
                lines.Add(GetRow(photo));
            }

            return lines;
        }

        private string WriteToFile(List<string> csvData)
        {
            var fileName = $"Photo Locator Export - {DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.csv";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fullPath = Path.Combine(desktopPath, fileName);

            File.WriteAllLines(fullPath, csvData);

            return fullPath;
        }

        private void OpenFile(string filePath)
        {
            try
            {
                Process.Start(filePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Unable to open csv file at path {filePath}. {ex.Message}");
            }
        }
    }
}
