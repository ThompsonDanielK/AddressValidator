import { Address } from "../data/CsvParser";

const TranformAddresses = (
  parsedAddresses: Address[],
  validatedAddresses: any[]
): string[] => {
  const transformedAddresses = parsedAddresses.map((address, index) => {
    const validatedAddress = validatedAddresses.find(
      (validatedAddress: any) => {
        return index === validatedAddress.input_index;
      }
    );

    if (validatedAddress) {
      return `${address.street}, ${address.city}, ${address.zipcode} -> ${
        validatedAddress.components.primary_number
      } ${validatedAddress.components.street_name} ${
        validatedAddress.components.street_suffix
      }, ${validatedAddress.components.city_name}, ${
        validatedAddress.components.zipcode
      }${
        validatedAddress.components.plus4_code
          ? `-${validatedAddress.components.plus4_code}`
          : ""
      }`;
    } else {
      return `${address.street}, ${address.city}, ${address.zipcode} -> Invalid Address`;
    }
  });

  return transformedAddresses;
};

export default TranformAddresses;
