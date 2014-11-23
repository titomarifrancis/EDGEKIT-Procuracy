using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AirconditioningAndAirconditiViewModel : ViewModelBase<AirconditioningAndAirconditiSchema>
    {
        private RelayCommandEx<AirconditioningAndAirconditiSchema> itemClickCommand;
        public RelayCommandEx<AirconditioningAndAirconditiSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AirconditioningAndAirconditiSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AirconditioningAndAirconditiDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AirconditioningAndAirconditiSchema> CreateDataSource()
        {
            return new AirconditioningAndAirconditiDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AirconditioningAndAirconditiList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AirconditioningAndAirconditiDetail");
        }
    }
}
