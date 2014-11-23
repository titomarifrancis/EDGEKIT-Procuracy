using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the AgriculturalChemicalsSchema class.
    /// </summary>
    public class AgriculturalChemicalsSchema : BindableSchemaBase, IEquatable<AgriculturalChemicalsSchema>, ISyncItem<AgriculturalChemicalsSchema>
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

        public bool Equals(AgriculturalChemicalsSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(AgriculturalChemicalsSchema other)
        {

            //NO COLUMNS, COMPARE IDS ONLY
            return this.Id == other.Id;
        }

        public void Sync(AgriculturalChemicalsSchema other)
        {
            
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AgriculturalChemicalsSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
