using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class ExecutiveSoleDistributorViewModel : ViewModelBase<ExecutiveSoleDistributorSchema>
    {
        private RelayCommandEx<ExecutiveSoleDistributorSchema> itemClickCommand;
        public RelayCommandEx<ExecutiveSoleDistributorSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<ExecutiveSoleDistributorSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("ExecutiveSoleDistributorDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<ExecutiveSoleDistributorSchema> CreateDataSource()
        {
            return new ExecutiveSoleDistributorDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("ExecutiveSoleDistributorList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("ExecutiveSoleDistributorDetail");
        }
    }
}
