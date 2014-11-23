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
    public sealed partial class AirconditioningAndAirconditi1Page : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AirconditioningAndAirconditi1Page()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AirconditioningAndAirconditi1Model = new AirconditioningAndAirconditi1ViewModel();
            DataContext = this;

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AirconditioningAndAirconditi1ViewModel AirconditioningAndAirconditi1Model { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);
            await AirconditioningAndAirconditi1Model.LoadItemsAsync();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (AirconditioningAndAirconditi1Model != null)
            {
                AirconditioningAndAirconditi1Model.GetShareContent(args.Request);
            }
        }
    }
}
