using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AppliancesViewModel : ViewModelBase<AppliancesSchema>
    {
        private RelayCommandEx<AppliancesSchema> itemClickCommand;
        public RelayCommandEx<AppliancesSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AppliancesSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AppliancesDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AppliancesSchema> CreateDataSource()
        {
            return new AppliancesDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AppliancesList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AppliancesDetail");
        }
    }
}
