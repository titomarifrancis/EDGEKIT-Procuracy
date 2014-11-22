using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class DistributorViewModel : ViewModelBase<DistributorSchema>
    {
        private RelayCommandEx<DistributorSchema> itemClickCommand;
        public RelayCommandEx<DistributorSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<DistributorSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("DistributorDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<DistributorSchema> CreateDataSource()
        {
            return new DistributorDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("DistributorList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("DistributorDetail");
        }
    }
}
