using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class ManufacturerViewModel : ViewModelBase<ManufacturerSchema>
    {
        private RelayCommandEx<ManufacturerSchema> itemClickCommand;
        public RelayCommandEx<ManufacturerSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<ManufacturerSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("ManufacturerDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<ManufacturerSchema> CreateDataSource()
        {
            return new ManufacturerDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("ManufacturerList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("ManufacturerDetail");
        }
    }
}
