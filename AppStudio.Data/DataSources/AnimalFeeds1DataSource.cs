using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AnimalFeeds1DataSource : DataSourceBase<AnimalFeeds1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "5f548cbc-cd33-4a0d-943b-f123c3d792f0";

        protected override string CacheKey
        {
            get { return "AnimalFeeds1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AnimalFeeds1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AnimalFeeds1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AnimalFeeds1DataSource.LoadData", ex.ToString());
                return new AnimalFeeds1Schema[0];
            }
        }
    }
}
