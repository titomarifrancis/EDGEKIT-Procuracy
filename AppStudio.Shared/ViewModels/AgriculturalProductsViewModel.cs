using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AgriculturalProductsViewModel : ViewModelBase<AgriculturalProductsSchema>
    {
        private RelayCommandEx<AgriculturalProductsSchema> itemClickCommand;
        public RelayCommandEx<AgriculturalProductsSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AgriculturalProductsSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AgriculturalProductsDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AgriculturalProductsSchema> CreateDataSource()
        {
            return new AgriculturalProductsDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AgriculturalProductsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AgriculturalProductsDetail");
        }
    }
}
