using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AircraftSparePartsDataSource : DataSourceBase<AircraftSparePartsSchema>
    {
        private const string _file = "/Assets/Data/AircraftSparePartsDataSource.json";

        protected override string CacheKey
        {
            get { return "AircraftSparePartsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AircraftSparePartsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AircraftSparePartsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AircraftSparePartsDataSource.LoadData", ex.ToString());
                return new AircraftSparePartsSchema[0];
            }
        }
    }
}
