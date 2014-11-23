using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AircraftSpareParts1ViewModel : ViewModelBase<AircraftSpareParts1Schema>
    {
        private RelayCommandEx<AircraftSpareParts1Schema> itemClickCommand;
        public RelayCommandEx<AircraftSpareParts1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AircraftSpareParts1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AircraftSpareParts1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AircraftSpareParts1Schema> CreateDataSource()
        {
            return new AircraftSpareParts1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AircraftSpareParts1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AircraftSpareParts1Detail");
        }
    }
}
