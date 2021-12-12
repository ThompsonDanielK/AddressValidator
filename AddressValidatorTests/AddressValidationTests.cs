using AddressValidator.Data;
using AddressValidator.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AddressValidatorTests
{
    [TestClass]
    public class AddressValidationTests
    {
        [DataTestMethod]
        [DynamicData(nameof(ValidateAddressesTestData), DynamicDataSourceType.Method)]
        public void ValidateAddresses_SetsValidatedAddressesToOldAndNewAddresses(string[] addresses, string[] validatedAddresses, string[] expected)
        {
            //Arrange
            AddressValidation ops = new AddressValidation();
            List<Address> addressList = new List<Address>();
            List<string> validatedAddressList = new List<string>();

            foreach (string item in addresses)
            {
                List<string> singleAddress = item.Split(", ").ToList();

                Address address = new Address()
                {
                    StreetAddress = singleAddress[0],
                    City = singleAddress[1],
                    PostalCode = singleAddress[2]
                };

                addressList.Add(address);
            }

            ops.Addresses = addressList;

            //Act
            int index = 0;
            foreach (string validatedAddress in validatedAddresses)
            {
                ops.ValidateAddresses(true, validatedAddress);

                validatedAddressList.Add(ops.ValidatedAddresses[index]);
                ops.ValidatedAddresses.Clear();
                index++;
            }

            //Assert
            CollectionAssert.AreEqual(expected.ToList(), validatedAddressList);
            
        }

        public static IEnumerable<object[]> ValidateAddressesTestData()
        {
            return new object [][]
            {
                new string[][] { new string[] { "1111 LookieLou road, Whoville, 00000", "2222 NosieNelly street, Pieville, 11111" },
                new string[] { "1111 LookieLou Rd, Whoville, 00000-11111", "2222 NosieNelly St, Pieville, 11111-22222" },
                new string[] { "1111 LookieLou road, Whoville, 00000 -> 1111 LookieLou Rd, Whoville, 00000-11111", "2222 NosieNelly street, Pieville, 11111 -> 2222 NosieNelly St, Pieville, 11111-22222" }},
            };
        }

        
    }
}
