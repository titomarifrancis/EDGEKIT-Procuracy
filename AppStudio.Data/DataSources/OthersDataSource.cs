using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class OthersDataSource : DataSourceBase<OthersSchema>
    {
        private const string _file = "/Assets/Data/OthersDataSource.json";

        protected override string CacheKey
        {
            get { return "OthersDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<OthersSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<OthersSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("OthersDataSource.LoadData", ex.ToString());
                return new OthersSchema[0];
            }
        }
    }
}
