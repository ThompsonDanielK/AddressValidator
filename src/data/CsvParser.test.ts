import ParseCSV from "./CsvParser";

describe("parseCSV", () => {
  it("should parse a CSV file and return an array of objects", async () => {
    const filePath = "src/data/test.csv";
    const expected = [
      { Street: "143 e Maine Street", City: "Columbus", "Zip Code": "43215" },
      { Street: "1 Empora St", City: "Title", "Zip Code": "11111" },
    ];

    const result = await ParseCSV(filePath);

    expect(result).toEqual(expected);
  });

  it("should reject with an error if the file does not exist", async () => {
    const filePath = "nonexistent.csv";

    expect(ParseCSV(filePath)).rejects.toThrow("File not found");
  });
});
