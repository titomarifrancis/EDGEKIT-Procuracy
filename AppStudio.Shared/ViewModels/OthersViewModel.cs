using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class OthersViewModel : ViewModelBase<OthersSchema>
    {
        private RelayCommandEx<OthersSchema> itemClickCommand;
        public RelayCommandEx<OthersSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<OthersSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("OthersDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<OthersSchema> CreateDataSource()
        {
            return new OthersDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("OthersList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("OthersDetail");
        }
    }
}
