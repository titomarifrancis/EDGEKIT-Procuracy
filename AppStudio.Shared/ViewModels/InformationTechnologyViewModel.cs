using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class InformationTechnologyViewModel : ViewModelBase<InformationTechnologySchema>
    {
        private RelayCommandEx<InformationTechnologySchema> itemClickCommand;
        public RelayCommandEx<InformationTechnologySchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<InformationTechnologySchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("InformationTechnologyDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<InformationTechnologySchema> CreateDataSource()
        {
            return new InformationTechnologyDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("InformationTechnologyList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("InformationTechnologyDetail");
        }
    }
}
