using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AgriculturalMachineryAndEquDataSource : DataSourceBase<AgriculturalMachineryAndEquSchema>
    {
        private const string _file = "/Assets/Data/AgriculturalMachineryAndEquDataSource.json";

        protected override string CacheKey
        {
            get { return "AgriculturalMachineryAndEquDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<AgriculturalMachineryAndEquSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AgriculturalMachineryAndEquSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AgriculturalMachineryAndEquDataSource.LoadData", ex.ToString());
                return new AgriculturalMachineryAndEquSchema[0];
            }
        }
    }
}
