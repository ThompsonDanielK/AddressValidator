import axios from "axios";

import { Address } from "../data/CsvParser";

const ValidateAddresses = async (
  addresses: Address[],
  authId: string,
  authToken: string
) => {
  try {
    const queryParams = {
      "auth-id": authId,
      "auth-token": authToken,
    };

    const body = JSON.stringify(addresses);
    const response = await axios.post(
      "https://us-street.api.smarty.com/street-address",
      body,
      {
        params: queryParams,
      }
    );

    return response.data;
  } catch (error) {
    console.error("Error validating addresses:", error);
    throw error;
  }
};

export default ValidateAddresses;
