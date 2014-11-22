using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DistributorDataSource : DataSourceBase<DistributorSchema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "c8883c90-39fb-437a-8046-a8ad35125a00";

        protected override string CacheKey
        {
            get { return "DistributorDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<DistributorSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<DistributorSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("DistributorDataSource.LoadData", ex.ToString());
                return new DistributorSchema[0];
            }
        }
    }
}
