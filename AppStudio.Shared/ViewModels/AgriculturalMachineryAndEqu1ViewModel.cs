using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AgriculturalMachineryAndEqu1ViewModel : ViewModelBase<AgriculturalMachineryAndEqu1Schema>
    {
        private RelayCommandEx<AgriculturalMachineryAndEqu1Schema> itemClickCommand;
        public RelayCommandEx<AgriculturalMachineryAndEqu1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AgriculturalMachineryAndEqu1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AgriculturalMachineryAndEqu1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AgriculturalMachineryAndEqu1Schema> CreateDataSource()
        {
            return new AgriculturalMachineryAndEqu1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AgriculturalMachineryAndEqu1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AgriculturalMachineryAndEqu1Detail");
        }
    }
}
