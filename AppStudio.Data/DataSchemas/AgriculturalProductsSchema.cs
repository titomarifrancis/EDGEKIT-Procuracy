using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the AgriculturalProductsSchema class.
    /// </summary>
    public class AgriculturalProductsSchema : BindableSchemaBase, IEquatable<AgriculturalProductsSchema>, ISyncItem<AgriculturalProductsSchema>
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

        public bool Equals(AgriculturalProductsSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(AgriculturalProductsSchema other)
        {

            //NO COLUMNS, COMPARE IDS ONLY
            return this.Id == other.Id;
        }

        public void Sync(AgriculturalProductsSchema other)
        {
            
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AgriculturalProductsSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
