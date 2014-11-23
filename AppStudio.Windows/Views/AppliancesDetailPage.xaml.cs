using System;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;

using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class AppliancesDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AppliancesDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            SizeChanged += OnSizeChanged;

            AppliancesModel = new AppliancesViewModel();
        }

        public AppliancesViewModel AppliancesModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 500)
            {
                VisualStateManager.GoToState(this, "SnappedView", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "FullscreenView", true);
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (AppliancesModel != null)
            {
                await AppliancesModel.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    AppliancesModel.SelectItem(e.Parameter);
                }

                AppliancesModel.ViewType = ViewTypes.Detail;
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
            if (AppliancesModel != null)
            {
                AppliancesModel.GetShareContent(args.Request);
            }
        }
    }
}
