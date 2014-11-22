using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class GeneralMerchandiseDataSource : DataSourceBase<GeneralMerchandiseSchema>
    {
        private const string _file = "/Assets/Data/GeneralMerchandiseDataSource.json";

        protected override string CacheKey
        {
            get { return "GeneralMerchandiseDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<GeneralMerchandiseSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<GeneralMerchandiseSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("GeneralMerchandiseDataSource.LoadData", ex.ToString());
                return new GeneralMerchandiseSchema[0];
            }
        }
    }
}
