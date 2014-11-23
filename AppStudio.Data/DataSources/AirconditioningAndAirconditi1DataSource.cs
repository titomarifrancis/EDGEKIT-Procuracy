using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AirconditioningAndAirconditi1DataSource : DataSourceBase<AirconditioningAndAirconditi1Schema>
    {
        private const string _file = "/Assets/Data/AirconditioningAndAirconditi1DataSource.json";

        protected override string CacheKey
        {
            get { return "AirconditioningAndAirconditi1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AirconditioningAndAirconditi1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AirconditioningAndAirconditi1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AirconditioningAndAirconditi1DataSource.LoadData", ex.ToString());
                return new AirconditioningAndAirconditi1Schema[0];
            }
        }
    }
}
