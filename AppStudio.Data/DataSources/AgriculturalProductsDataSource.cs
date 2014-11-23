using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AgriculturalProductsDataSource : DataSourceBase<AgriculturalProductsSchema>
    {
        private const string _file = "/Assets/Data/AgriculturalProductsDataSource.json";

        protected override string CacheKey
        {
            get { return "AgriculturalProductsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AgriculturalProductsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AgriculturalProductsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AgriculturalProductsDataSource.LoadData", ex.ToString());
                return new AgriculturalProductsSchema[0];
            }
        }
    }
}
