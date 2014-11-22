using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class InformationTechnologyDataSource : DataSourceBase<InformationTechnologySchema>
    {
        private const string _file = "/Assets/Data/InformationTechnologyDataSource.json";

        protected override string CacheKey
        {
            get { return "InformationTechnologyDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<InformationTechnologySchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<InformationTechnologySchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("InformationTechnologyDataSource.LoadData", ex.ToString());
                return new InformationTechnologySchema[0];
            }
        }
    }
}
