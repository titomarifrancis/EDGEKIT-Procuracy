using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AgriculturalMachineryAndEqu1DataSource : DataSourceBase<AgriculturalMachineryAndEqu1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "6982985a-3db8-4061-8d58-3d9f7237e242";

        protected override string CacheKey
        {
            get { return "AgriculturalMachineryAndEqu1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AgriculturalMachineryAndEqu1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AgriculturalMachineryAndEqu1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AgriculturalMachineryAndEqu1DataSource.LoadData", ex.ToString());
                return new AgriculturalMachineryAndEqu1Schema[0];
            }
        }
    }
}
