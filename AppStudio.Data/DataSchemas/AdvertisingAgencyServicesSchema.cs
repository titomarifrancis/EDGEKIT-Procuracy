using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the AdvertisingAgencyServicesSchema class.
    /// </summary>
    public class AdvertisingAgencyServicesSchema : BindableSchemaBase, IEquatable<AdvertisingAgencyServicesSchema>, ISyncItem<AdvertisingAgencyServicesSchema>
    {
        private string _classification;
        private string _closingtime;
        private string _price;
        private string _contactperson;
        private string _deliveryperiod;
        private string _email;
        private string _procuringentity;
        private string _referencenumber;
        private string _address;
        private string _description;
        private string _contact;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string classification
        {
            get { return _classification; }
            set { SetProperty(ref _classification, value); }
        }
 
        public string closingtime
        {
            get { return _closingtime; }
            set { SetProperty(ref _closingtime, value); }
        }
 
        public string price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
 
        public string contactperson
        {
            get { return _contactperson; }
            set { SetProperty(ref _contactperson, value); }
        }
 
        public string deliveryperiod
        {
            get { return _deliveryperiod; }
            set { SetProperty(ref _deliveryperiod, value); }
        }
 
        public string email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
 
        public string procuringentity
        {
            get { return _procuringentity; }
            set { SetProperty(ref _procuringentity, value); }
        }
 
        public string referencenumber
        {
            get { return _referencenumber; }
            set { SetProperty(ref _referencenumber, value); }
        }
 
        public string address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }
 
        public string description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
 
        public string contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }

        public override string DefaultTitle
        {
            get { return classification; }
        }

        public override string DefaultSummary
        {
            get { return closingtime; }
        }

        public override string DefaultImageUrl
        {
            get { return null; }
        }

        public override string DefaultContent
        {
            get { return closingtime; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "classification":
                        return String.Format("{0}", classification); 
                    case "closingtime":
                        return String.Format("{0}", closingtime); 
                    case "price":
                        return String.Format("{0}", price); 
                    case "contactperson":
                        return String.Format("{0}", contactperson); 
                    case "deliveryperiod":
                        return String.Format("{0}", deliveryperiod); 
                    case "email":
                        return String.Format("{0}", email); 
                    case "procuringentity":
                        return String.Format("{0}", procuringentity); 
                    case "referencenumber":
                        return String.Format("{0}", referencenumber); 
                    case "address":
                        return String.Format("{0}", address); 
                    case "description":
                        return String.Format("{0}", description); 
                    case "contact":
                        return String.Format("{0}", contact); 
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

        public bool Equals(AdvertisingAgencyServicesSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(AdvertisingAgencyServicesSchema other)
        {

            return this.Id == other.Id && (this.classification != other.classification || this.closingtime != other.closingtime || this.price != other.price || this.contactperson != other.contactperson || this.deliveryperiod != other.deliveryperiod || this.email != other.email || this.procuringentity != other.procuringentity || this.referencenumber != other.referencenumber || this.address != other.address || this.description != other.description || this.contact != other.contact);
        }

        public void Sync(AdvertisingAgencyServicesSchema other)
        {
            this.classification = other.classification;
            this.closingtime = other.closingtime;
            this.price = other.price;
            this.contactperson = other.contactperson;
            this.deliveryperiod = other.deliveryperiod;
            this.email = other.email;
            this.procuringentity = other.procuringentity;
            this.referencenumber = other.referencenumber;
            this.address = other.address;
            this.description = other.description;
            this.contact = other.contact;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AdvertisingAgencyServicesSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
