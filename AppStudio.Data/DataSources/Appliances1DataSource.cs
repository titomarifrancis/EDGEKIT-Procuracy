using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class Appliances1DataSource : DataSourceBase<Appliances1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "75454747-150e-4378-b43d-f3c39a28159c";

        protected override string CacheKey
        {
            get { return "Appliances1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<Appliances1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<Appliances1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("Appliances1DataSource.LoadData", ex.ToString());
                return new Appliances1Schema[0];
            }
        }
    }
}
