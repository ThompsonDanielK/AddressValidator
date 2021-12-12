using System;
using AddressValidator.APIClient;
using AddressValidator.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressValidatorTests
{
    [TestClass]
    public class AddressServiceTests
    {
        [TestMethod]
        [DataRow(new string[] { "1111 Fake Rd", "Johnsonville", "99999-88888" }, "1111 Fake Rd, Johnsonville, 99999-88888")]
        public void BuildValidatedAddressString_ReturnsCorrectString(string[] input, string expected)
        {
            //Arrange
            Address inputAddress = new Address(input[0], input[1], input[2]);
            inputAddress.FormattedAddress = input[0];
            AddressService ops = new AddressService();

            //Act
            string result = ops.BuildValidatedAddressString(inputAddress);

            //Assert
            Assert.AreEqual(expected, result);

        }
    }
}
