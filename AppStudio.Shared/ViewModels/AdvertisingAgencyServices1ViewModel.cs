using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AdvertisingAgencyServices1ViewModel : ViewModelBase<AdvertisingAgencyServices1Schema>
    {
        private RelayCommandEx<AdvertisingAgencyServices1Schema> itemClickCommand;
        public RelayCommandEx<AdvertisingAgencyServices1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AdvertisingAgencyServices1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AdvertisingAgencyServices1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AdvertisingAgencyServices1Schema> CreateDataSource()
        {
            return new AdvertisingAgencyServices1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AdvertisingAgencyServices1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AdvertisingAgencyServices1Detail");
        }
    }
}
