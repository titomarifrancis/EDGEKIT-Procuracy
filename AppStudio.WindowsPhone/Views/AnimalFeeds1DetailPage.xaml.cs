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
    public sealed partial class AnimalFeeds1Detail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AnimalFeeds1Detail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AnimalFeeds1Model = new AnimalFeeds1ViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AnimalFeeds1ViewModel AnimalFeeds1Model { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (AnimalFeeds1Model != null)
            {
                await AnimalFeeds1Model.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    AnimalFeeds1Model.SelectItem(e.Parameter);
                }

                AnimalFeeds1Model.ViewType = ViewTypes.Detail;
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
            if (AnimalFeeds1Model != null)
            {
                AnimalFeeds1Model.GetShareContent(args.Request);
            }
        }
    }
}
