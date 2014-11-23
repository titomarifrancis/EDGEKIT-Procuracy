using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AirconditioningAndAirconditiDataSource : DataSourceBase<AirconditioningAndAirconditiSchema>
    {
        private const string _file = "/Assets/Data/AirconditioningAndAirconditiDataSource.json";

        protected override string CacheKey
        {
            get { return "AirconditioningAndAirconditiDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AirconditioningAndAirconditiSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AirconditioningAndAirconditiSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AirconditioningAndAirconditiDataSource.LoadData", ex.ToString());
                return new AirconditioningAndAirconditiSchema[0];
            }
        }
    }
}
