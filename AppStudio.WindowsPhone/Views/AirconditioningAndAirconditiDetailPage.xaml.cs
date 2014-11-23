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
    public sealed partial class AirconditioningAndAirconditiDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AirconditioningAndAirconditiDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AirconditioningAndAirconditiModel = new AirconditioningAndAirconditiViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AirconditioningAndAirconditiViewModel AirconditioningAndAirconditiModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (AirconditioningAndAirconditiModel != null)
            {
                await AirconditioningAndAirconditiModel.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    AirconditioningAndAirconditiModel.SelectItem(e.Parameter);
                }

                AirconditioningAndAirconditiModel.ViewType = ViewTypes.Detail;
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
            if (AirconditioningAndAirconditiModel != null)
            {
                AirconditioningAndAirconditiModel.GetShareContent(args.Request);
            }
        }
    }
}
