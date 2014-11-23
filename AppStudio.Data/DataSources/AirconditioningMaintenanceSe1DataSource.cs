using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AirconditioningMaintenanceSe1DataSource : DataSourceBase<AirconditioningMaintenanceSe1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "a60bf597-b285-4246-9f7b-e83820226c24";

        protected override string CacheKey
        {
            get { return "AirconditioningMaintenanceSe1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AirconditioningMaintenanceSe1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AirconditioningMaintenanceSe1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AirconditioningMaintenanceSe1DataSource.LoadData", ex.ToString());
                return new AirconditioningMaintenanceSe1Schema[0];
            }
        }
    }
}
