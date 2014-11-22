using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class GeneralMerchandiseViewModel : ViewModelBase<GeneralMerchandiseSchema>
    {
        private RelayCommandEx<GeneralMerchandiseSchema> itemClickCommand;
        public RelayCommandEx<GeneralMerchandiseSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<GeneralMerchandiseSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("GeneralMerchandiseDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<GeneralMerchandiseSchema> CreateDataSource()
        {
            return new GeneralMerchandiseDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("GeneralMerchandiseList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("GeneralMerchandiseDetail");
        }
    }
}
