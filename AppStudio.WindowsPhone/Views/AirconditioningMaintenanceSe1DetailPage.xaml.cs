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
    public sealed partial class AirconditioningMaintenanceSe1Detail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AirconditioningMaintenanceSe1Detail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AirconditioningMaintenanceSe1Model = new AirconditioningMaintenanceSe1ViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AirconditioningMaintenanceSe1ViewModel AirconditioningMaintenanceSe1Model { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (AirconditioningMaintenanceSe1Model != null)
            {
                await AirconditioningMaintenanceSe1Model.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    AirconditioningMaintenanceSe1Model.SelectItem(e.Parameter);
                }

                AirconditioningMaintenanceSe1Model.ViewType = ViewTypes.Detail;
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
            if (AirconditioningMaintenanceSe1Model != null)
            {
                AirconditioningMaintenanceSe1Model.GetShareContent(args.Request);
            }
        }
    }
}
