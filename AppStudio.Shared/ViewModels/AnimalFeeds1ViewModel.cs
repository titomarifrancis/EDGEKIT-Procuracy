using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AnimalFeeds1ViewModel : ViewModelBase<AnimalFeeds1Schema>
    {
        private RelayCommandEx<AnimalFeeds1Schema> itemClickCommand;
        public RelayCommandEx<AnimalFeeds1Schema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AnimalFeeds1Schema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AnimalFeeds1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AnimalFeeds1Schema> CreateDataSource()
        {
            return new AnimalFeeds1DataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AnimalFeeds1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AnimalFeeds1Detail");
        }
    }
}
