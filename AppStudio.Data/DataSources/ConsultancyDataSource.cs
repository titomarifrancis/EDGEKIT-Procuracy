using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ConsultancyDataSource : DataSourceBase<ConsultancySchema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "8ed069e6-0b52-4f3f-9e77-0fd80d5528d1";

        protected override string CacheKey
        {
            get { return "ConsultancyDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<ConsultancySchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<ConsultancySchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ConsultancyDataSource.LoadData", ex.ToString());
                return new ConsultancySchema[0];
            }
        }
    }
}
