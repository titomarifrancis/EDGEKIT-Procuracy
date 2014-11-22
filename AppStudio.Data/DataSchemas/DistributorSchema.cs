using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the DistributorSchema class.
    /// </summary>
    public class DistributorSchema : BindableSchemaBase, IEquatable<DistributorSchema>, ISyncItem<DistributorSchema>
    {
        private string _org_name;
        private string _website;
        private string _org_description;
        private string _address;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string org_name
        {
            get { return _org_name; }
            set { SetProperty(ref _org_name, value); }
        }
 
        public string website
        {
            get { return _website; }
            set { SetProperty(ref _website, value); }
        }
 
        public string org_description
        {
            get { return _org_description; }
            set { SetProperty(ref _org_description, value); }
        }
 
        public string address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        public override string DefaultTitle
        {
            get { return org_name; }
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
                    case "org_name":
                        return String.Format("{0}", org_name); 
                    case "website":
                        return String.Format("{0}", website); 
                    case "org_description":
                        return String.Format("{0}", org_description); 
                    case "address":
                        return String.Format("{0}", address); 
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

        public bool Equals(DistributorSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(DistributorSchema other)
        {

            return this.Id == other.Id && (this.org_name != other.org_name || this.website != other.website || this.org_description != other.org_description || this.address != other.address);
        }

        public void Sync(DistributorSchema other)
        {
            this.org_name = other.org_name;
            this.website = other.website;
            this.org_description = other.org_description;
            this.address = other.address;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DistributorSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
