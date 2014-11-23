using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AgriculturalChemicals1DataSource : DataSourceBase<AgriculturalChemicals1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "56eb7b15-548c-4149-ae16-31b66d6e42c5";

        protected override string CacheKey
        {
            get { return "AgriculturalChemicals1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AgriculturalChemicals1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AgriculturalChemicals1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AgriculturalChemicals1DataSource.LoadData", ex.ToString());
                return new AgriculturalChemicals1Schema[0];
            }
        }
    }
}
