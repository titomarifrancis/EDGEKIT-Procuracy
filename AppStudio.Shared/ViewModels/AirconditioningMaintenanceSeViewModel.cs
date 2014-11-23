using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AirconditioningMaintenanceSeViewModel : ViewModelBase<AirconditioningMaintenanceSeSchema>
    {
        private RelayCommandEx<AirconditioningMaintenanceSeSchema> itemClickCommand;
        public RelayCommandEx<AirconditioningMaintenanceSeSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AirconditioningMaintenanceSeSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AirconditioningMaintenanceSeDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AirconditioningMaintenanceSeSchema> CreateDataSource()
        {
            return new AirconditioningMaintenanceSeDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AirconditioningMaintenanceSeList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AirconditioningMaintenanceSeDetail");
        }
    }
}
