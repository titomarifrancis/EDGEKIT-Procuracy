using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AgriculturalMachineryAndEquViewModel : ViewModelBase<AgriculturalMachineryAndEquSchema>
    {
        private RelayCommandEx<AgriculturalMachineryAndEquSchema> itemClickCommand;
        public RelayCommandEx<AgriculturalMachineryAndEquSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AgriculturalMachineryAndEquSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AgriculturalMachineryAndEquDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AgriculturalMachineryAndEquSchema> CreateDataSource()
        {
            return new AgriculturalMachineryAndEquDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AgriculturalMachineryAndEquList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AgriculturalMachineryAndEquDetail");
        }
    }
}
