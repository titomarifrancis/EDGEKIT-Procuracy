using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AgriculturalProducts1ViewModel : ViewModelBase<AgriculturalProducts1Schema>
    {
        private RelayCommandEx<AgriculturalProducts1Schema> itemClickCommand;
        public RelayCommandEx<AgriculturalProducts1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AgriculturalProducts1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AgriculturalProducts1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AgriculturalProducts1Schema> CreateDataSource()
        {
            return new AgriculturalProducts1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AgriculturalProducts1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AgriculturalProducts1Detail");
        }
    }
}
