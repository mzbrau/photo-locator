using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PhotoLocator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMainWindowViewModel _vm;

        public MainWindow()
        {
            _vm = new MainWindowViewModel();
            DataContext = _vm;

            InitializeComponent();

            _vm.SetControls(BingMap);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            _vm.OpenFiles();
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            _vm.RenameAll();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            _vm.ShowSettings();
        }

        private void ExportAll_Click(object sender, RoutedEventArgs e)
        {
            _vm.ExportAll();
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            _vm.ShowAll();
        }

        private void NavigateToPhoto(object sender, MouseButtonEventArgs e)
        {
            _vm.NavigateToImage();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _vm.OpenImage();
        }

        private void SelectCurrentItem(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            item.IsSelected = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.ShowSettingsIfNoBingMapsKey();
        }

        private void PhotoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as ListView;

            if (list != null)
            {
                list.ScrollIntoView(list.SelectedItem);
            }
        }
    }
}
