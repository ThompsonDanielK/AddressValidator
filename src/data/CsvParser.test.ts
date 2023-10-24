import ParseCSV from "./CsvParser";

describe("ParseCSV", () => {
  it("should parse a CSV file and return an array of objects", async () => {
    const filePath = "src/data/test.csv";
    const expected = [
      { street: "143 e Maine Street", city: "Columbus", zipcode: "43215" },
      { street: "1 Empora St", city: "Title", zipcode: "11111" },
    ];

    const result = await ParseCSV(filePath);

    expect(result).toEqual(expected);
  });

  it("should reject with an error if the file does not exist", async () => {
    const filePath = "nonexistent.csv";

    expect(ParseCSV(filePath)).rejects.toThrow("File not found");
  });
});
