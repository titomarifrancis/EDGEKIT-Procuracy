using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AirconditioningMaintenanceSe1ViewModel : ViewModelBase<AirconditioningMaintenanceSe1Schema>
    {
        private RelayCommandEx<AirconditioningMaintenanceSe1Schema> itemClickCommand;
        public RelayCommandEx<AirconditioningMaintenanceSe1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AirconditioningMaintenanceSe1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AirconditioningMaintenanceSe1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AirconditioningMaintenanceSe1Schema> CreateDataSource()
        {
            return new AirconditioningMaintenanceSe1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AirconditioningMaintenanceSe1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AirconditioningMaintenanceSe1Detail");
        }
    }
}
