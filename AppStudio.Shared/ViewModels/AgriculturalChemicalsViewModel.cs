using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AgriculturalChemicalsViewModel : ViewModelBase<AgriculturalChemicalsSchema>
    {
        private RelayCommandEx<AgriculturalChemicalsSchema> itemClickCommand;
        public RelayCommandEx<AgriculturalChemicalsSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AgriculturalChemicalsSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AgriculturalChemicalsDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AgriculturalChemicalsSchema> CreateDataSource()
        {
            return new AgriculturalChemicalsDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AgriculturalChemicalsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AgriculturalChemicalsDetail");
        }
    }
}
