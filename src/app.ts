import ParseCSV from "./data/CsvParser";
import TransformAddresses from "./services/AddressTransformer";
import ValidateAddresses from "./services/AddressValidatorClient";

const main = async () => {
  try {
    const args = process.argv.slice(2);

    if (args.length < 3) {
      throw new Error(
        "Insufficient number of arguments. Please provide file path, authId, and authToken."
      );
    }

    const filePath = args[0];
    const authId = args[1];
    const authToken = args[2];

    const parsedAddresses = await ParseCSV(filePath);
    const validatedAddresses = await ValidateAddresses(
      parsedAddresses,
      authId,
      authToken
    );
    const transformedAddresses = TransformAddresses(
      parsedAddresses,
      validatedAddresses
    );
    // Do something with validatedAddresses, for example, log them
    console.log("Transformed Addresses:", transformedAddresses);
  } catch (error) {
    console.error("Error:", error);
  }
};

main();
