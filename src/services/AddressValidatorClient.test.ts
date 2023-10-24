import axios from "axios";

import ValidateAddresses from "./AddressValidatorClient";

jest.mock("axios");

describe("validateAddresses", () => {
  const authId = "test-auth-id";
  const authToken = "test-auth-token";
  const addresses = [
    {
      street: "123 Main St",
      city: "Anytown",
      zipcode: "12345",
    },
    {
      street: "456 Oak Ave",
      city: "Othertown",
      zipcode: "67890",
    },
  ];

  it("should call the SmartyStreets API with the correct parameters", async () => {
    const expectedParams = {
      "auth-id": authId,
      "auth-token": authToken,
    };

    const expectedResponse = { success: true };

    (axios.post as jest.Mock).mockResolvedValueOnce({
      data: expectedResponse,
    });

    const response = await ValidateAddresses(addresses, authId, authToken);

    expect(axios.post).toHaveBeenCalledWith(
      "https://us-street.api.smarty.com/street-address",
      JSON.stringify(addresses),
      {
        params: expectedParams,
      }
    );

    expect(response).toEqual(expectedResponse);
  });

  it("should throw an error if the API call fails", async () => {
    const expectedError = new Error("API call failed");

    (axios.post as jest.Mock).mockRejectedValueOnce(expectedError);

    await expect(
      ValidateAddresses(addresses, authId, authToken)
    ).rejects.toThrow(expectedError);
  });
});
