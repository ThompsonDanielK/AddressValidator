using System;
using System.Collections.Generic;
using System.Text;

namespace AddressValidator.Data
{
    /// <summary>
    /// This is the Data model for requests sent to the API and responses received for the API
    /// </summary>
    public class Address
    {
        public string Status { get; set; }

        public string CountryCode { get; set; } = "USA";

        public string StreetAddress { get; set; }

        public string AdditionalAddressInfo { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string FormattedAddress { get; set; }

        public Address()
        {

        }

        public Address(List<string> addresses)
        {
            this.StreetAddress = addresses[0];
            this.City = addresses[1];
            this.PostalCode = addresses[2];
        } 
        
        public Address(string streetAddress, string city, string postalCode)
        {
            this.StreetAddress = streetAddress;
            this.City = city;
            this.PostalCode = postalCode;
        }
    }
}
