using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AgriculturalChemicals1ViewModel : ViewModelBase<AgriculturalChemicals1Schema>
    {
        private RelayCommandEx<AgriculturalChemicals1Schema> itemClickCommand;
        public RelayCommandEx<AgriculturalChemicals1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AgriculturalChemicals1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AgriculturalChemicals1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AgriculturalChemicals1Schema> CreateDataSource()
        {
            return new AgriculturalChemicals1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AgriculturalChemicals1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AgriculturalChemicals1Detail");
        }
    }
}
