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
    public sealed partial class AmmunitionsAndExplosives1Detail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AmmunitionsAndExplosives1Detail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AmmunitionsAndExplosives1Model = new AmmunitionsAndExplosives1ViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public AmmunitionsAndExplosives1ViewModel AmmunitionsAndExplosives1Model { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (AmmunitionsAndExplosives1Model != null)
            {
                await AmmunitionsAndExplosives1Model.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    AmmunitionsAndExplosives1Model.SelectItem(e.Parameter);
                }

                AmmunitionsAndExplosives1Model.ViewType = ViewTypes.Detail;
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
            if (AmmunitionsAndExplosives1Model != null)
            {
                AmmunitionsAndExplosives1Model.GetShareContent(args.Request);
            }
        }
    }
}
