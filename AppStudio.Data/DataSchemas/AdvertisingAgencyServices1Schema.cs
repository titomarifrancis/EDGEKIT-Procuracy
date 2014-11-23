using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the AdvertisingAgencyServices1Schema class.
    /// </summary>
    public class AdvertisingAgencyServices1Schema : BindableSchemaBase, IEquatable<AdvertisingAgencyServices1Schema>, ISyncItem<AdvertisingAgencyServices1Schema>
    {
        private string _title;
        private string _amount;
        private string _awardees;
        private string _contact;
        private string _awardeesaddress;
        private string _contactaddress;
        private string _telephone;
        private string _organizationname;
        private string _organizationaddress;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
 
        public string amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
 
        public string awardees
        {
            get { return _awardees; }
            set { SetProperty(ref _awardees, value); }
        }
 
        public string contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }
 
        public string awardeesaddress
        {
            get { return _awardeesaddress; }
            set { SetProperty(ref _awardeesaddress, value); }
        }
 
        public string contactaddress
        {
            get { return _contactaddress; }
            set { SetProperty(ref _contactaddress, value); }
        }
 
        public string telephone
        {
            get { return _telephone; }
            set { SetProperty(ref _telephone, value); }
        }
 
        public string organizationname
        {
            get { return _organizationname; }
            set { SetProperty(ref _organizationname, value); }
        }
 
        public string organizationaddress
        {
            get { return _organizationaddress; }
            set { SetProperty(ref _organizationaddress, value); }
        }

        public override string DefaultTitle
        {
            get { return title; }
        }

        public override string DefaultSummary
        {
            get { return amount; }
        }

        public override string DefaultImageUrl
        {
            get { return null; }
        }

        public override string DefaultContent
        {
            get { return amount; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "title":
                        return String.Format("{0}", title); 
                    case "amount":
                        return String.Format("{0}", amount); 
                    case "awardees":
                        return String.Format("{0}", awardees); 
                    case "contact":
                        return String.Format("{0}", contact); 
                    case "awardeesaddress":
                        return String.Format("{0}", awardeesaddress); 
                    case "contactaddress":
                        return String.Format("{0}", contactaddress); 
                    case "telephone":
                        return String.Format("{0}", telephone); 
                    case "organizationname":
                        return String.Format("{0}", organizationname); 
                    case "organizationaddress":
                        return String.Format("{0}", organizationaddress); 
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

        public bool Equals(AdvertisingAgencyServices1Schema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(AdvertisingAgencyServices1Schema other)
        {

            return this.Id == other.Id && (this.title != other.title || this.amount != other.amount || this.awardees != other.awardees || this.contact != other.contact || this.awardeesaddress != other.awardeesaddress || this.contactaddress != other.contactaddress || this.telephone != other.telephone || this.organizationname != other.organizationname || this.organizationaddress != other.organizationaddress);
        }

        public void Sync(AdvertisingAgencyServices1Schema other)
        {
            this.title = other.title;
            this.amount = other.amount;
            this.awardees = other.awardees;
            this.contact = other.contact;
            this.awardeesaddress = other.awardeesaddress;
            this.contactaddress = other.contactaddress;
            this.telephone = other.telephone;
            this.organizationname = other.organizationname;
            this.organizationaddress = other.organizationaddress;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AdvertisingAgencyServices1Schema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
