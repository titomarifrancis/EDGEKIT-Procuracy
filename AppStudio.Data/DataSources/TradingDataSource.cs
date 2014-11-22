using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class TradingDataSource : DataSourceBase<TradingSchema>
    {
        private const string _file = "/Assets/Data/TradingDataSource.json";

        protected override string CacheKey
        {
            get { return "TradingDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<TradingSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<TradingSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("TradingDataSource.LoadData", ex.ToString());
                return new TradingSchema[0];
            }
        }
    }
}
