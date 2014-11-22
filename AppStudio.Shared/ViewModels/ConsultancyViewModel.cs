using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class ConsultancyViewModel : ViewModelBase<ConsultancySchema>
    {
        private RelayCommandEx<ConsultancySchema> itemClickCommand;
        public RelayCommandEx<ConsultancySchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<ConsultancySchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("ConsultancyDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<ConsultancySchema> CreateDataSource()
        {
            return new ConsultancyDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("ConsultancyList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("ConsultancyDetail");
        }
    }
}
