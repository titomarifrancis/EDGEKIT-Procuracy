using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AgriculturalProducts1DataSource : DataSourceBase<AgriculturalProducts1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "51766c1a-8604-4a40-b5fc-f2d8f830b07f";

        protected override string CacheKey
        {
            get { return "AgriculturalProducts1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AgriculturalProducts1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AgriculturalProducts1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AgriculturalProducts1DataSource.LoadData", ex.ToString());
                return new AgriculturalProducts1Schema[0];
            }
        }
    }
}
