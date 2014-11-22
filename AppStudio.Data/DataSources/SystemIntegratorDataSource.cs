using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class SystemIntegratorDataSource : DataSourceBase<SystemIntegratorSchema>
    {
        private const string _file = "/Assets/Data/SystemIntegratorDataSource.json";

        protected override string CacheKey
        {
            get { return "SystemIntegratorDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<SystemIntegratorSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<SystemIntegratorSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("SystemIntegratorDataSource.LoadData", ex.ToString());
                return new SystemIntegratorSchema[0];
            }
        }
    }
}
