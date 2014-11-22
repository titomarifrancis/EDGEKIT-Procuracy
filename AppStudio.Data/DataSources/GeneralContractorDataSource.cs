using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class GeneralContractorDataSource : DataSourceBase<GeneralContractorSchema>
    {
        private const string _file = "/Assets/Data/GeneralContractorDataSource.json";

        protected override string CacheKey
        {
            get { return "GeneralContractorDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<GeneralContractorSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<GeneralContractorSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("GeneralContractorDataSource.LoadData", ex.ToString());
                return new GeneralContractorSchema[0];
            }
        }
    }
}
