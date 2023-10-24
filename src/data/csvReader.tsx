import { parse } from "csv-parse";
import * as fs from "fs";

interface CsvRow {
  address: string;
  city: string;
  zip: number;
}

export default async function parseCSV(filePath: string): Promise<CsvRow[]> {
  const results: CsvRow[] = [];

  return new Promise((resolve, reject) => {
    fs.access(filePath, fs.constants.F_OK, (err) => {
      if (err) {
        return reject(new Error("File not found"));
      }
    });

    fs.createReadStream(filePath)
      .pipe(parse({ columns: true, trim: true }))
      .on("data", (row: CsvRow) => {
        results.push(row);
      })
      .on("end", () => {
        resolve(results);
      })
      .on("error", (error) => {
        console.error("Error:", error);
        reject(error);
      });
  });
}
