using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class NonGovernmentOrganizationDataSource : DataSourceBase<NonGovernmentOrganizationSchema>
    {
        private const string _file = "/Assets/Data/NonGovernmentOrganizationDataSource.json";

        protected override string CacheKey
        {
            get { return "NonGovernmentOrganizationDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<NonGovernmentOrganizationSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<NonGovernmentOrganizationSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("NonGovernmentOrganizationDataSource.LoadData", ex.ToString());
                return new NonGovernmentOrganizationSchema[0];
            }
        }
    }
}
