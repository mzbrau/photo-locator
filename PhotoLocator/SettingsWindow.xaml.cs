using BingMapsRESTToolkit;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhotoLocator
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private string _initialKey;

        public SettingsWindow(string bingKey)
        {
            InitializeComponent();
            BingKey.Text = bingKey;
            SetSaveButtonEnabledState();
            _initialKey = bingKey;
        }

        public string BingMapsKey { get; private set; }



        private void GetKey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(@"https://docs.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to show webpage. {ex.Message}");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            BingMapsKey = BingKey.Text;
            this.Close();
        }

        private void SetSaveButtonEnabledState()
        {
            var key = BingKey.Text;
            Task reverseGeocode = Task.Factory.StartNew<bool>(() =>
            {
                return ValidateBingCall(key);

            }).ContinueWith((isKeyValid) =>
            {
                SaveButton.IsEnabled = isKeyValid.Result;

                if (_initialKey != key)
                    ShowResultBox(isKeyValid.Result);
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void ShowResultBox(bool isValid)
        {
            if (isValid)
            {
                MessageBox.Show("Valid key entered.", "Valid", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Key was invalid.", "Invalid", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private bool ValidateBingCall(string key)
        {
            var r = new ReverseGeocodeRequest()
            {
                // New York
                Point = new Coordinate(40.771390, -73.964529),
                IncludeNeighborhood = true,
                BingMapsKey = key
            };

            var response = r.Execute((rt) => { }).Result;

            return response.AuthenticationResultCode == "ValidCredentials";
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            SetSaveButtonEnabledState();
        }

        private void BingKey_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = false;
        }
    }
}
