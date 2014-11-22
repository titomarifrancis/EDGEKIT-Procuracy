using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ManufacturerDataSource : DataSourceBase<ManufacturerSchema>
    {
        private const string _file = "/Assets/Data/ManufacturerDataSource.json";

        protected override string CacheKey
        {
            get { return "ManufacturerDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<ManufacturerSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<ManufacturerSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ManufacturerDataSource.LoadData", ex.ToString());
                return new ManufacturerSchema[0];
            }
        }
    }
}
