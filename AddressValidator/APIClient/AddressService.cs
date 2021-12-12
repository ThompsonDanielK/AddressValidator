using System;
using System.Collections.Generic;
using System.Text;
using AddressValidator.Data;
using RestSharp;

namespace AddressValidator.APIClient
{
    /// <summary>
    /// This class is responsible for all calls to the external API.
    /// </summary>
    public class AddressService
    {
        private const string API_BASE_URL = "https://api.address-validator.net/api/verify/";
        private const string API_KEY = "av-21a50c0fa3fde35755a857584fb17f57";
        private readonly IRestClient client = new RestClient();

        /// <summary>
        /// Builds and sends request to external API
        /// </summary>
        /// <param name="addressToBeValidated">This is the input address to be sent to the API</param>
        /// <returns>A formatted address string</returns>
        public string ValidateAddressRequest(Address addressToBeValidated)
        {
            RestRequest request = new RestRequest($"{API_BASE_URL}");
            request.AddQueryParameter("StreetAddress", addressToBeValidated.StreetAddress);
            request.AddQueryParameter("City", addressToBeValidated.City);
            request.AddQueryParameter("PostalCode", addressToBeValidated.PostalCode);
            request.AddQueryParameter("APIKey", API_KEY);

            if (addressToBeValidated.CountryCode != "")
            {
                request.AddQueryParameter("CountryCode", addressToBeValidated.CountryCode);
            }
            if (addressToBeValidated.AdditionalAddressInfo != "")
            {
                request.AddQueryParameter("AdditionalAddressInfo", addressToBeValidated.AdditionalAddressInfo);
            }
            if (addressToBeValidated.State != "")
            {
                request.AddQueryParameter("State", addressToBeValidated.State);
            }

            IRestResponse<Address> response = client.Get<Address>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Could not communicate with the server");
            }

            string validatedAddress = BuildValidatedAddressString(response.Data);

            return validatedAddress;
        }

        /// <summary>
        /// Builds and formats address strings
        /// </summary>
        /// <param name="address">The address object to be formatted</param>
        /// <returns>A properly formatted address string</returns>
        public string BuildValidatedAddressString(Address address)
        {
            string validatedAddress;

            if (address.Status != "INVALID")
            {
                validatedAddress = $"{address.FormattedAddress.Split(",")[0]}, {address.City}, {address.PostalCode}";
            }
            else
            {
                validatedAddress = address.Status;
            }


            return validatedAddress;
        }

        public AddressService()
        {

        }
    }
}
