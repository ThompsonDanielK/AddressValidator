import TransformAddresses from "./AddressTransformer";

describe("TransformAddresses", () => {
  const parsedAddresses = [
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

  const validatedAddresses = [
    {
      input_index: 0,
      components: {
        primary_number: "123",
        street_name: "Main",
        street_suffix: "St",
        city_name: "Anytown",
        zipcode: "12345",
        plus4_code: "6789",
      },
    },
    {
      input_index: 1,
      components: {
        primary_number: "456",
        street_name: "Oak",
        street_suffix: "Ave",
        city_name: "Othertown",
        zipcode: "67890",
      },
    },
  ];

  it("should transform valid addresses correctly", () => {
    const expectedTransformedAddresses = [
      "123 Main St, Anytown, 12345 -> 123 Main St, Anytown, 12345-6789",
      "456 Oak Ave, Othertown, 67890 -> 456 Oak Ave, Othertown, 67890",
    ];

    const transformedAddresses = TransformAddresses(
      parsedAddresses,
      validatedAddresses
    );

    expect(transformedAddresses).toEqual(expectedTransformedAddresses);
  });

  it("should transform invalid addresses correctly", () => {
    const invalidValidatedAddresses: any[] = [];

    const expectedTransformedAddresses = [
      "123 Main St, Anytown, 12345 -> Invalid Address",
      "456 Oak Ave, Othertown, 67890 -> Invalid Address",
    ];

    const transformedAddresses = TransformAddresses(
      parsedAddresses,
      invalidValidatedAddresses
    );

    expect(transformedAddresses).toEqual(expectedTransformedAddresses);
  });
});
