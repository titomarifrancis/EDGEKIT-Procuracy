using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AdvertisingAgencyServices1DataSource : DataSourceBase<AdvertisingAgencyServices1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "e7b923df-130a-4bcd-ad9f-827f4b091e6d";

        protected override string CacheKey
        {
            get { return "AdvertisingAgencyServices1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AdvertisingAgencyServices1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AdvertisingAgencyServices1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AdvertisingAgencyServices1DataSource.LoadData", ex.ToString());
                return new AdvertisingAgencyServices1Schema[0];
            }
        }
    }
}
