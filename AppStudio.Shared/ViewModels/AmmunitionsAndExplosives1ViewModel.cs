using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AmmunitionsAndExplosives1ViewModel : ViewModelBase<AmmunitionsAndExplosives1Schema>
    {
        private RelayCommandEx<AmmunitionsAndExplosives1Schema> itemClickCommand;
        public RelayCommandEx<AmmunitionsAndExplosives1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AmmunitionsAndExplosives1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AmmunitionsAndExplosives1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AmmunitionsAndExplosives1Schema> CreateDataSource()
        {
            return new AmmunitionsAndExplosives1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AmmunitionsAndExplosives1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AmmunitionsAndExplosives1Detail");
        }
    }
}
