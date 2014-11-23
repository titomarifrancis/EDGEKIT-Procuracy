using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class AnimalFeedsViewModel : ViewModelBase<AnimalFeedsSchema>
    {
        private RelayCommandEx<AnimalFeedsSchema> itemClickCommand;
        public RelayCommandEx<AnimalFeedsSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<AnimalFeedsSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("AnimalFeedsDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<AnimalFeedsSchema> CreateDataSource()
        {
            return new AnimalFeedsDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("AnimalFeedsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("AnimalFeedsDetail");
        }
    }
}
