using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AdvertisingAgencyServicesViewModel : ViewModelBase<AdvertisingAgencyServicesSchema>
    {
        private RelayCommandEx<AdvertisingAgencyServicesSchema> itemClickCommand;
        public RelayCommandEx<AdvertisingAgencyServicesSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AdvertisingAgencyServicesSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AdvertisingAgencyServicesDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AdvertisingAgencyServicesSchema> CreateDataSource()
        {
            return new AdvertisingAgencyServicesDataSource(); // CollectionDataSource
            }


        override public Visibility RefreshVisibility
        {
            get { return ViewType == ViewTypes.List ? Visibility.Visible : Visibility.Collapsed; }
        }

        public RelayCommandEx<Slider> IncreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value++);
            }
        }

        public RelayCommandEx<Slider> DecreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value--);
            }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("AdvertisingAgencyServicesList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AdvertisingAgencyServicesDetail");
        }
    }
}
