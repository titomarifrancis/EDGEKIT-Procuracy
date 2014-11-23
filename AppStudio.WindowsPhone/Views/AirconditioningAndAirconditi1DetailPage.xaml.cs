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
    public sealed partial class AirconditioningAndAirconditi1Detail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AirconditioningAndAirconditi1Detail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AirconditioningAndAirconditi1Model = new AirconditioningAndAirconditi1ViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AirconditioningAndAirconditi1ViewModel AirconditioningAndAirconditi1Model { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (AirconditioningAndAirconditi1Model != null)
            {
                await AirconditioningAndAirconditi1Model.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    AirconditioningAndAirconditi1Model.SelectItem(e.Parameter);
                }

                AirconditioningAndAirconditi1Model.ViewType = ViewTypes.Detail;
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
            if (AirconditioningAndAirconditi1Model != null)
            {
                AirconditioningAndAirconditi1Model.GetShareContent(args.Request);
            }
        }
    }
}
