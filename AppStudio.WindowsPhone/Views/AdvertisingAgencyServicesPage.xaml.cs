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
    public sealed partial class AdvertisingAgencyServicesPage : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AdvertisingAgencyServicesPage()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AdvertisingAgencyServicesModel = new AdvertisingAgencyServicesViewModel();
            DataContext = this;

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AdvertisingAgencyServicesViewModel AdvertisingAgencyServicesModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);
            await AdvertisingAgencyServicesModel.LoadItemsAsync();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (AdvertisingAgencyServicesModel != null)
            {
                AdvertisingAgencyServicesModel.GetShareContent(args.Request);
            }
        }
    }
}
