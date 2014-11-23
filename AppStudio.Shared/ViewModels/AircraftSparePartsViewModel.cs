using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AircraftSparePartsViewModel : ViewModelBase<AircraftSparePartsSchema>
    {
        private RelayCommandEx<AircraftSparePartsSchema> itemClickCommand;
        public RelayCommandEx<AircraftSparePartsSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AircraftSparePartsSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AircraftSparePartsDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AircraftSparePartsSchema> CreateDataSource()
        {
            return new AircraftSparePartsDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AircraftSparePartsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AircraftSparePartsDetail");
        }
    }
}
