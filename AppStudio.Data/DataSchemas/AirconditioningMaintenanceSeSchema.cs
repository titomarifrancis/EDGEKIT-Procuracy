using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the AirconditioningMaintenanceSeSchema class.
    /// </summary>
    public class AirconditioningMaintenanceSeSchema : BindableSchemaBase, IEquatable<AirconditioningMaintenanceSeSchema>, ISyncItem<AirconditioningMaintenanceSeSchema>
    {
        [JsonProperty("_id")]
        public string Id { get; set; }


        public override string DefaultTitle
        {
            get { return null; }
        }

        public override string DefaultSummary
        {
            get { return null; }
        }

        public override string DefaultImageUrl
        {
            get { return null; }
        }

        public override string DefaultContent
        {
            get { return null; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }

        public bool Equals(AirconditioningMaintenanceSeSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(AirconditioningMaintenanceSeSchema other)
        {

            //NO COLUMNS, COMPARE IDS ONLY
            return this.Id == other.Id;
        }

        public void Sync(AirconditioningMaintenanceSeSchema other)
        {
            
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AirconditioningMaintenanceSeSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
