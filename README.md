# AddressValidator

AddressValidator is a C# console application for validating address through use of an external API. This application reads addresses from input.csv and sends them to an external API for validation. The response contains a validated address, which is written to output.csv along with original address that was sent to the API.


## Installation

1. Using Visual Studio, open AddressValidator.sln.

2. Navigate to the Solution Explorer. 

3. Click to arrow icon next to AddressValidator to expand the file. 

4. Click the icon next to the folder, APIClient.

5. Double click AddressService to view the code.

6. Locate line 14 of AddressService, it should look like this:

```C#
private const string API_KEY = "YOUR_KEY_HERE";
```
7. Replace YOUR_KEY_HERE with your API key.

8. Click the save icon or press CTRL+S on your keyboard.

## Usage
1. Open input.csv with your preferred text editor, input.csv is in the same directory as AddressValidator.sln.

2. Input the addresses you want to validate in this format: 
```
Street Address, City, Postal Code
1111 Sunshine Boulevard, Atlantis, 12345
```

3. Click the save icon or press CTRL+S on your keyboard.

4. If AddressValidator.sln is no longer open, use Visual Studio to open AddressValidator.sln.

5. Press F5 on your keyboard. A console window will open and will tell you when the process is complete.

6. Validated address can be retrieved in output.csv, this file is located in the same directory as input.csv and AddressValidator.sln.

## Run Tests
1. If AddressValidator.sln is no longer open, use Visual Studio to open AddressValidator.sln.

2. Navigate to the top of Visual Studio and click Test then Run All Tests. Or you can use the keyboard shortcut, CTRL+R then A.

## Application Structure

1. AddressValidator
    - APIClient
        - AddressService.cs
    - Data
        - Address.cs
    - FileIO
        - FileAccess.cs
    - Operations
        - AddressValidation.cs
    - Program.cs
    - UserInterface.cs
2. AddressValidatorTests
    - AddressServiceTests.cs
    - AddressValidationTests.cs

## Technical Description

AddressValidator was developed in C# using Visual Studio 2019. I decided to design the above application structure while keeping expansion in mind. I also wanted to divide up the function of the application into separate classes.

The Program.cs class creates a new instance of the class, UserInterface.cs, and calls the method, ApplicationStart, from that instance.

UserInterface.cs handles delivering success and error messages to the user. UserInterface.cs instantiates both FileAccess and AddressValidation. The only method this class contains, ApplicationStart, calls ReadInputFile from FileAccess.cs, then ValidateAddresses from AddressValidation.cs, then writes the result to the output file with WriteOutputFile from FileAccess.cs.

All reading and writing to files is handled by the FileAccess.cs class in the FileIO folder. FileAccess.cs contains the methods: ReadInputFile, which takes in an AddressValidation object as a parameter, and WriteOutputFile, which also takes in an AddressValidation object as a parameter. Let's talk about these methods in-depth.

1. ReadInputFile reads input.csv line by line and splits each string up into 3 pieces. A new Address.cs object is created and the 3 pieces of the input string are assigned to the following properties of Address.cs: StreetAddress, City, PostalCode. That object is then added to the list property, Addresses, within the AddressValidation object that was passed into the method as a parameter.

2. WriteOutputFile loops through all strings in the ValidatedAddress property of AddressValidation, which was passed into the property as a parameter. It writes each string to a single line. Each string is the combination of the inputted address and the validated address received from the API.

This application has one data model, Address.cs. Address.cs contains the properties: Status, CountryCode, StreetAddress, AdditionalAddressInfo, City, PostalCode, State, FormattedAddress. It also contains a default constructor, a constructor that takes in a list of strings, and a constructor that takes in 3 separate strings.

All API communications to https://api.address-validator.net/api/verify/ are handled by AddressService.cs within the APIClient folder. It has three private fields: API_KEY, which contains the API key needed to query the API, API_BASE_URL, which contains the API URL, and IRestClient client, which contains the RestClient used in making API calls. AddressService.cs contains the methods, ValidateAddressRequest, which takes in a single Address object as a parameter, and the method, BuildValidatedAddressString, which also takes in a single Address object as a parameter.

1. Using the Address object, ValidateAddressRequest builds a RestRequest. Query parameters are added for StreetAddress, City, PostalCode, and APIKey. It then sends the request. Once a response is received, the data from the response is passed into the BuildValidatedAddressString method. ValidateAddressRequest returns a string containing the properly formatted address.

3. Using the Address object, BuildValidatedAddressString checks the Status property of the Address object. If the Status property DOES NOT equal "INVALID", the Address object is converted into a string containing the street address, city, and postal code. This is then returned. All items are separated by a comma and a space. If the Status property equals "INVALID", "Invalid Address" is returned.

AddressValidation.cs contains the properties: Addresses, a list of Address objects, ValidatedAddresses, a list of strings containing inputted addresses and validated addresses, and AddressService service, which contains a new instance of AddressService. The only method in this class, ValidateAddresses, loops through each Address object in Addresses and calls the method ValidateAddressRequest from the AddressService object, service. ValidatedAddressRequest returns the validated address as a string. The inputted address and validated address are then combined into one string and added to the list, ValidatedAddresses.