using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ExecutiveSoleDistributorDataSource : DataSourceBase<ExecutiveSoleDistributorSchema>
    {
        private const string _file = "/Assets/Data/ExecutiveSoleDistributorDataSource.json";

        protected override string CacheKey
        {
            get { return "ExecutiveSoleDistributorDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<ExecutiveSoleDistributorSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<ExecutiveSoleDistributorSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ExecutiveSoleDistributorDataSource.LoadData", ex.ToString());
                return new ExecutiveSoleDistributorSchema[0];
            }
        }
    }
}
