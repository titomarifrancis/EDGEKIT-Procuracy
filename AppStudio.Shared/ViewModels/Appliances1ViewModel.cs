using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class Appliances1ViewModel : ViewModelBase<Appliances1Schema>
    {
        private RelayCommandEx<Appliances1Schema> itemClickCommand;
        public RelayCommandEx<Appliances1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<Appliances1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("Appliances1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<Appliances1Schema> CreateDataSource()
        {
            return new Appliances1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("Appliances1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("Appliances1Detail");
        }
    }
}
