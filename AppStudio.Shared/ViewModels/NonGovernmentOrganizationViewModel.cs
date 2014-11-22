using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class NonGovernmentOrganizationViewModel : ViewModelBase<NonGovernmentOrganizationSchema>
    {
        private RelayCommandEx<NonGovernmentOrganizationSchema> itemClickCommand;
        public RelayCommandEx<NonGovernmentOrganizationSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<NonGovernmentOrganizationSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("NonGovernmentOrganizationDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<NonGovernmentOrganizationSchema> CreateDataSource()
        {
            return new NonGovernmentOrganizationDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("NonGovernmentOrganizationList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("NonGovernmentOrganizationDetail");
        }
    }
}
