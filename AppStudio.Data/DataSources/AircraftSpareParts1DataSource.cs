using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AircraftSpareParts1DataSource : DataSourceBase<AircraftSpareParts1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "e4028a30-ba1e-4546-8e2a-f4107a3dcd8b";

        protected override string CacheKey
        {
            get { return "AircraftSpareParts1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AircraftSpareParts1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AircraftSpareParts1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AircraftSpareParts1DataSource.LoadData", ex.ToString());
                return new AircraftSpareParts1Schema[0];
            }
        }
    }
}
