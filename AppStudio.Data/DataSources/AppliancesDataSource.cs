using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AppliancesDataSource : DataSourceBase<AppliancesSchema>
    {
        private const string _file = "/Assets/Data/AppliancesDataSource.json";

        protected override string CacheKey
        {
            get { return "AppliancesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AppliancesSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AppliancesSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AppliancesDataSource.LoadData", ex.ToString());
                return new AppliancesSchema[0];
            }
        }
    }
}
