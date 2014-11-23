using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AmmunitionsAndExplosives1DataSource : DataSourceBase<AmmunitionsAndExplosives1Schema>
    {
        private const string _appId = "c2ebbcd7-64df-4118-96f4-1bf314b97ae3";
        private const string _dataSourceName = "2755ee1e-cd19-44da-accf-a33091c96a12";

        protected override string CacheKey
        {
            get { return "AmmunitionsAndExplosives1DataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AmmunitionsAndExplosives1Schema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                return await serviceDataProvider.Load<AmmunitionsAndExplosives1Schema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AmmunitionsAndExplosives1DataSource.LoadData", ex.ToString());
                return new AmmunitionsAndExplosives1Schema[0];
            }
        }
    }
}
