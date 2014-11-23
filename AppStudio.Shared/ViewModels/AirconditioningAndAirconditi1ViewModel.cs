using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AirconditioningAndAirconditi1ViewModel : ViewModelBase<AirconditioningAndAirconditi1Schema>
    {
        private RelayCommandEx<AirconditioningAndAirconditi1Schema> itemClickCommand;
        public RelayCommandEx<AirconditioningAndAirconditi1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AirconditioningAndAirconditi1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AirconditioningAndAirconditi1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AirconditioningAndAirconditi1Schema> CreateDataSource()
        {
            return new AirconditioningAndAirconditi1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AirconditioningAndAirconditi1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AirconditioningAndAirconditi1Detail");
        }
    }
}
