using System;
using System.Net.NetworkInformation;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class AircraftSpareParts1Page : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AircraftSpareParts1Page()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AircraftSpareParts1Model = new AircraftSpareParts1ViewModel();
            DataContext = this;

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AircraftSpareParts1ViewModel AircraftSpareParts1Model { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);
            await AircraftSpareParts1Model.LoadItemsAsync();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (AircraftSpareParts1Model != null)
            {
                AircraftSpareParts1Model.GetShareContent(args.Request);
            }
        }
    }
}
