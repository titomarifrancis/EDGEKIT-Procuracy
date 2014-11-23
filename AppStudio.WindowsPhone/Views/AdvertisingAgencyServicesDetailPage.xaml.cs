using System;
using System.Net.NetworkInformation;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class AdvertisingAgencyServicesDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AdvertisingAgencyServicesDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AdvertisingAgencyServicesModel = new AdvertisingAgencyServicesViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AdvertisingAgencyServicesViewModel AdvertisingAgencyServicesModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            await AdvertisingAgencyServicesModel.LoadItemsAsync();
            AdvertisingAgencyServicesModel.SelectItem(e.Parameter);

            if (AdvertisingAgencyServicesModel != null)
            {
                AdvertisingAgencyServicesModel.ViewType = ViewTypes.Detail;
            }
            DataContext = this;
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
