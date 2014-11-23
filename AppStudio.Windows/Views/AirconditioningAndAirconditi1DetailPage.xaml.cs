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
    public sealed partial class AirconditioningAndAirconditi1Detail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AirconditioningAndAirconditi1Detail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            SizeChanged += OnSizeChanged;

            AirconditioningAndAirconditi1Model = new AirconditioningAndAirconditi1ViewModel();
        }

        public AirconditioningAndAirconditi1ViewModel AirconditioningAndAirconditi1Model { get; private set; }

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
