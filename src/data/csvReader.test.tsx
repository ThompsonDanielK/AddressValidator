import parseCSV from "./csvReader";

describe("parseCSV", () => {
  it("should parse a CSV file and return an array of objects", async () => {
    const filePath = "test.csv";
    const expected = [
      { Street: "143 e Maine Street", City: "Columbus", "Zip Code": "43215" },
      { Street: "1 Empora St", City: "Title", "Zip Code": "11111" },
    ];

    const result = await parseCSV(filePath);
    console.log(result);
    expect(result).toEqual(expected);
  });

  it("should reject with an error if the file does not exist", async () => {
    const filePath = "nonexistent.csv";

    expect(parseCSV(filePath)).rejects.toThrow("File not found");
  });
});
