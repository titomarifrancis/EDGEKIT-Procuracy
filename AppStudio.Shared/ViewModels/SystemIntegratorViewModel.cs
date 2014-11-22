using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class SystemIntegratorViewModel : ViewModelBase<SystemIntegratorSchema>
    {
        private RelayCommandEx<SystemIntegratorSchema> itemClickCommand;
        public RelayCommandEx<SystemIntegratorSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<SystemIntegratorSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("SystemIntegratorDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<SystemIntegratorSchema> CreateDataSource()
        {
            return new SystemIntegratorDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("SystemIntegratorList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("SystemIntegratorDetail");
        }
    }
}
