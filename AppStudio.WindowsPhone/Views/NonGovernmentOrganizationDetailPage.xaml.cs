using System;
using System.Net.NetworkInformation;

using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class NonGovernmentOrganizationDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public NonGovernmentOrganizationDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            NonGovernmentOrganizationModel = new NonGovernmentOrganizationViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public NonGovernmentOrganizationViewModel NonGovernmentOrganizationModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (NonGovernmentOrganizationModel != null)
            {
                await NonGovernmentOrganizationModel.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    NonGovernmentOrganizationModel.SelectItem(e.Parameter);
                }

                NonGovernmentOrganizationModel.ViewType = ViewTypes.Detail;
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
            if (NonGovernmentOrganizationModel != null)
            {
                NonGovernmentOrganizationModel.GetShareContent(args.Request);
            }
        }
    }
}
