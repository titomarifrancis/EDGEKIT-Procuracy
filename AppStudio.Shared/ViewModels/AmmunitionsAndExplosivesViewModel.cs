using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AmmunitionsAndExplosivesViewModel : ViewModelBase<AmmunitionsAndExplosivesSchema>
    {
        private RelayCommandEx<AmmunitionsAndExplosivesSchema> itemClickCommand;
        public RelayCommandEx<AmmunitionsAndExplosivesSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AmmunitionsAndExplosivesSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AmmunitionsAndExplosivesDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AmmunitionsAndExplosivesSchema> CreateDataSource()
        {
            return new AmmunitionsAndExplosivesDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AmmunitionsAndExplosivesList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AmmunitionsAndExplosivesDetail");
        }
    }
}
