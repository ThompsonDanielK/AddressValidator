# US Address Validator

This command-line program validates US addresses using the Smarty US Address Verification API. It takes input from a CSV file, validates the addresses, and outputs the original and corrected addresses.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Tests](#tests)
- [API Key](#api-key)
- [Example](#example)
- [Considerations](#considerations)

## Prerequisites

- Node.js installed on your system.
- You have an account on [smarty](https://www.smarty.com/products/us-address-verification).
- You have your authId and authToken from smarty.

## Installation

1. Clone this repository to your local machine.
2. Run `yarn install` to install the required dependencies.

## Build

1. Run `yarn build` to build the application.

## Usage

To run the program, navigate to the root directory of the application use the following command in the terminal:

```sh
yarn start filepath\to\your\input.csv authId authToken
```

Replace filepath\to\your\input.csv with the path to your CSV file containing addresses to validate.

Replace authId with your auth-id from smarty.

Replace authToken with your auth-token from smarty.

## Tests

To run tests, use the following command:

```
yarn test
```

## Example

Suppose you have a CSV file (\`input.csv\`) with the following content:

```
Street, City, Zip Code
143 e Maine Street, Columbus, 43215
1 Empora St, Title, 11111
```

Running the program with the above input will produce the following output:

```
143 e Maine Street, Columbus, 43215 -> 143 E Main St, Columbus, 43215-5370
1 Empora St, Title, 11111 -> Invalid Address
```

## Considerations

1. File Structure

```
/
├── src
│   ├── data
│   │   ├── CsvParser.test.ts
│   │   ├── CsvParser.ts
│   │   └── test.csv
│   ├── services
│   │   ├── AddressTransformer.test.ts
│   │   ├── AddressTransformer.ts
│   │   ├── AddressValidatorClient.test.ts
│   │   └── AddressValidatorClient.ts
│   └── app.ts
├── .gitignore
├── jest.config.js
├── package.json
├── README.md
├── tsconfig.json
└── yarn.lock
```

- Overall Struturing

  - I wanted to make this application as modular as possible. That way logic can easily be replaced without requiring major refactoring of the entire application.
  - As a personal preferences, I like my test files to be near the files they are testing. That is why tests are not in a seperate testing folder.

- The data folder containers all logic that interacts existing data.
  - CsvParser contains logic that will parse the inputed CSV and returns a list of objects
  - I used a third-party library to parse the CSV. I could write something from scratch but unless the application is supposed to be lightweight as possible, using this popular third party library made development faster.
- The service folder contains all logic that interacts with APIs and transforming data.

  - AddressTransformer takes the data retrieved via the API call to smarty and from the parsed CSV then formats in the desired way.
  - AddressValidatorClient uses Axios to make a POST requests to smarty, which returns a response containing corrected address information.

- app.ts is the entry point into the application. It calls all the logic listed above and prints the result to the console.

2. Testing

- I decided to use jest as my testing framework because that is what I'm familiar with.
- All functions are unit tested.
- API calls are mocked using jest.

3. Output to console

- This app could be configured to write to an output.csv, depending on the requirements.
