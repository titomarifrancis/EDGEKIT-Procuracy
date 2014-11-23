using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AmmunitionsAndExplosivesDataSource : DataSourceBase<AmmunitionsAndExplosivesSchema>
    {
        private const string _file = "/Assets/Data/AmmunitionsAndExplosivesDataSource.json";

        protected override string CacheKey
        {
            get { return "AmmunitionsAndExplosivesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AmmunitionsAndExplosivesSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AmmunitionsAndExplosivesSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AmmunitionsAndExplosivesDataSource.LoadData", ex.ToString());
                return new AmmunitionsAndExplosivesSchema[0];
            }
        }
    }
}
