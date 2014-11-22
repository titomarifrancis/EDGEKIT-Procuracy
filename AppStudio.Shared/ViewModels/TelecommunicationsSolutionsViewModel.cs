using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class TelecommunicationsSolutionsViewModel : ViewModelBase<TelecommunicationsSolutionsSchema>
    {
        private RelayCommandEx<TelecommunicationsSolutionsSchema> itemClickCommand;
        public RelayCommandEx<TelecommunicationsSolutionsSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<TelecommunicationsSolutionsSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("TelecommunicationsSolutionsDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<TelecommunicationsSolutionsSchema> CreateDataSource()
        {
            return new TelecommunicationsSolutionsDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("TelecommunicationsSolutionsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("TelecommunicationsSolutionsDetail");
        }
    }
}
