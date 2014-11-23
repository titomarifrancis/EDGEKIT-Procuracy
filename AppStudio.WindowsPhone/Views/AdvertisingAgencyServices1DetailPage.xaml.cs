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
    public sealed partial class AdvertisingAgencyServices1Detail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AdvertisingAgencyServices1Detail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AdvertisingAgencyServices1Model = new AdvertisingAgencyServices1ViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AdvertisingAgencyServices1ViewModel AdvertisingAgencyServices1Model { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            await AdvertisingAgencyServices1Model.LoadItemsAsync();
            AdvertisingAgencyServices1Model.SelectItem(e.Parameter);

            if (AdvertisingAgencyServices1Model != null)
            {
                AdvertisingAgencyServices1Model.ViewType = ViewTypes.Detail;
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
            if (AdvertisingAgencyServices1Model != null)
            {
                AdvertisingAgencyServices1Model.GetShareContent(args.Request);
            }
        }
    }
}
