using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class TradingViewModel : ViewModelBase<TradingSchema>
    {
        private RelayCommandEx<TradingSchema> itemClickCommand;
        public RelayCommandEx<TradingSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<TradingSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("TradingDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<TradingSchema> CreateDataSource()
        {
            return new TradingDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("TradingList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("TradingDetail");
        }
    }
}
