using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AnimalFeedsDataSource : DataSourceBase<AnimalFeedsSchema>
    {
        private const string _file = "/Assets/Data/AnimalFeedsDataSource.json";

        protected override string CacheKey
        {
            get { return "AnimalFeedsDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AnimalFeedsSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AnimalFeedsSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AnimalFeedsDataSource.LoadData", ex.ToString());
                return new AnimalFeedsSchema[0];
            }
        }
    }
}
