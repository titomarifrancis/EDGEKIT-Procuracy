using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the AmmunitionsAndExplosives1Schema class.
    /// </summary>
    public class AmmunitionsAndExplosives1Schema : BindableSchemaBase, IEquatable<AmmunitionsAndExplosives1Schema>, ISyncItem<AmmunitionsAndExplosives1Schema>
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

        public bool Equals(AmmunitionsAndExplosives1Schema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(AmmunitionsAndExplosives1Schema other)
        {

            //NO COLUMNS, COMPARE IDS ONLY
            return this.Id == other.Id;
        }

        public void Sync(AmmunitionsAndExplosives1Schema other)
        {
            
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AmmunitionsAndExplosives1Schema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
