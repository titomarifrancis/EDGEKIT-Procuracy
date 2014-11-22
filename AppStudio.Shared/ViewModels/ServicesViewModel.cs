using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class ServicesViewModel : ViewModelBase<ServicesSchema>
    {
        private RelayCommandEx<ServicesSchema> itemClickCommand;
        public RelayCommandEx<ServicesSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<ServicesSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("ServicesDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<ServicesSchema> CreateDataSource()
        {
            return new ServicesDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("ServicesList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("ServicesDetail");
        }
    }
}
