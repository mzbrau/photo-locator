using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace PhotoLocator
{
    interface IMainWindowViewModel
    {
        ObservableCollection<PhotoDefinition> Photos { get; }

        ICollectionView PhotoSource { get; }

        string FilterText { get; }

        /// <summary>
        /// Shows an open file dialog allowing the selection of files to open.
        /// </summary>
        void OpenFiles();

        /// <summary>
        /// Renames all photos in the list based on their taken date and location.
        /// </summary>
        void RenameAll();

        /// <summary>
        /// Exports details of all photos to CSV format.
        /// </summary>
        void ExportAll();

        /// <summary>
        /// Sets the map viewport such that all photos are visible.
        /// </summary>
        void ShowAll();

        /// <summary>
        /// Sets the map view port such that it centres the currently selected photo.
        /// </summary>
        void NavigateToImage();

        /// <summary>
        /// Opens the currently selected image in the default photo viewer for that format.
        /// </summary>
        void OpenImage();

        /// <summary>
        /// Makes the settings dialog visible.
        /// </summary>
        void ShowSettings();

        /// <summary>
        /// Passes the map control to the view model.
        /// </summary>
        /// <param name="map">The map control.</param>
        void SetControls(Map map);

        /// <summary>
        /// Shows the settings dialog if the bing maps key is not set.
        /// </summary>
        void ShowSettingsIfNoBingMapsKey();
    }
}
