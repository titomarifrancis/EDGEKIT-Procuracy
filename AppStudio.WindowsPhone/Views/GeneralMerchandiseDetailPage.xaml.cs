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
    public sealed partial class GeneralMerchandiseDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public GeneralMerchandiseDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            GeneralMerchandiseModel = new GeneralMerchandiseViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public GeneralMerchandiseViewModel GeneralMerchandiseModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (GeneralMerchandiseModel != null)
            {
                await GeneralMerchandiseModel.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    GeneralMerchandiseModel.SelectItem(e.Parameter);
                }

                GeneralMerchandiseModel.ViewType = ViewTypes.Detail;
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
            if (GeneralMerchandiseModel != null)
            {
                GeneralMerchandiseModel.GetShareContent(args.Request);
            }
        }
    }
}
