using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AirconditioningMaintenanceSeDataSource : DataSourceBase<AirconditioningMaintenanceSeSchema>
    {
        private const string _file = "/Assets/Data/AirconditioningMaintenanceSeDataSource.json";

        protected override string CacheKey
        {
            get { return "AirconditioningMaintenanceSeDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AirconditioningMaintenanceSeSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AirconditioningMaintenanceSeSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AirconditioningMaintenanceSeDataSource.LoadData", ex.ToString());
                return new AirconditioningMaintenanceSeSchema[0];
            }
        }
    }
}
