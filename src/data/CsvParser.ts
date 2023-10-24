import { parse } from "csv-parse";
import fs from "fs";

export interface Address {
  street: string;
  city: string;
  zipcode: string;
}

interface CsvRow {
  Street: string;
  City: string;
  "Zip Code": string;
}

const ParseCSV = async (filePath: string): Promise<Address[]> => {
  const results: Address[] = [];

  return new Promise((resolve, reject) => {
    fs.access(filePath, fs.constants.F_OK, (err) => {
      if (err) {
        return reject(new Error("File not found"));
      }

      fs.createReadStream(filePath)
        .pipe(parse({ columns: true, trim: true }))
        .on("data", (row: CsvRow) => {
          const address = {
            street: row.Street,
            city: row.City,
            zipcode: row["Zip Code"],
          };
          results.push(address);
        })
        .on("end", () => {
          resolve(results);
        })
        .on("error", (error: any) => {
          reject(error);
        });
    });
  });
};

export default ParseCSV;
