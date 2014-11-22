using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class GeneralContractorViewModel : ViewModelBase<GeneralContractorSchema>
    {
        private RelayCommandEx<GeneralContractorSchema> itemClickCommand;
        public RelayCommandEx<GeneralContractorSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<GeneralContractorSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("GeneralContractorDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<GeneralContractorSchema> CreateDataSource()
        {
            return new GeneralContractorDataSource(); // CollectionDataSource
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
            NavigationServices.NavigateToPage("GeneralContractorList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("GeneralContractorDetail");
        }
    }
}
