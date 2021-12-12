using AddressValidator.APIClient;
using AddressValidator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressValidator.Operations
{
    /// <summary>
    /// This class holds all inputed address and validated address, it also combines both inputed and validated address into one string.
    /// </summary>

    public class AddressValidation
    {
        public List<Address> Addresses { get; set; }

        public List<string> ValidatedAddresses { get; set; }

        private readonly AddressService service = new AddressService();

        /// <summary>
        /// This method loops through inputed address, calls ValidateAddressRequest on each address, which returns the validated address.
        /// This method also combines inputed address and validated addresses into a single string.
        /// </summary>
        /// <param name="test">If true, allows a sting to be substituted in place of the ValidateAddressRequest method call</param>
        /// <param name="testInput">Goes in place of the ValidatedAddressRequest method call</param>
        public void ValidateAddresses(bool test=false, string testInput="")
        {
            List<string> oldNewAddressPairs = new List<string>();

            if (!Addresses.Equals(null))
            {
                foreach (Address address in this.Addresses)
                {
                    string validatedAddress;
                    if (test)
                    {
                        validatedAddress = testInput;
                    }
                    else
                    {
                        validatedAddress = service.ValidateAddressRequest(address);
                    }

                    oldNewAddressPairs.Add($"{address.StreetAddress}, {address.City}, {address.PostalCode} -> {validatedAddress}");
                }
            }

            this.ValidatedAddresses = oldNewAddressPairs;
        }
    }
}