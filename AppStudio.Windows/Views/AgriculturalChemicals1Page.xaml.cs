using System;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class AgriculturalChemicals1Page : Page
    {
        private NavigationHelper _navigationHelper;

        public AgriculturalChemicals1Page()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AgriculturalChemicals1Model = new AgriculturalChemicals1ViewModel();
            DataContext = this;

            SizeChanged += OnSizeChanged;
        }

        public AgriculturalChemicals1ViewModel AgriculturalChemicals1Model { get; private set; }

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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
            await AgriculturalChemicals1Model.LoadItemsAsync();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }
    }
}
