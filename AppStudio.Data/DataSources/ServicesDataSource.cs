using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ServicesDataSource : DataSourceBase<ServicesSchema>
    {
        private const string _file = "/Assets/Data/ServicesDataSource.json";

        protected override string CacheKey
        {
            get { return "ServicesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<ServicesSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<ServicesSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ServicesDataSource.LoadData", ex.ToString());
                return new ServicesSchema[0];
            }
        }
    }
}
