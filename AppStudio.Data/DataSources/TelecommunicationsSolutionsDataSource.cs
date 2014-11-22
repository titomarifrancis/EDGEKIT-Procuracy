using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class TelecommunicationsSolutionsDataSource : DataSourceBase<TelecommunicationsSolutionsSchema>
    {
        private const string _file = "/Assets/Data/TelecommunicationsSolutionsDataSource.json";

        protected override string CacheKey
        {
            get { return "TelecommunicationsSolutionsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<TelecommunicationsSolutionsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<TelecommunicationsSolutionsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("TelecommunicationsSolutionsDataSource.LoadData", ex.ToString());
                return new TelecommunicationsSolutionsSchema[0];
            }
        }
    }
}
