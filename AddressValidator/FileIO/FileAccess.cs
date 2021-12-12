using AddressValidator.Data;
using AddressValidator.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AddressValidator.FileIO
{
    /// <summary>
    /// This class handles all reading and writing to files.
    /// </summary>
    public class FileAccess
    {
        string inputFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\input.csv"));
        string outputFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\output.csv"));

        /// <summary>
        /// Reads input file and creates Address Object for every line in file
        /// </summary>
        /// <param name="addressValidation">This object stores all address objects in a list.</param>
        /// <returns>A boolean that if true, means the operation was succesful</returns>
        public bool ReadInputFile(AddressValidation addressValidation)
        {
            try
            {
                List<Address> addresses = new List<Address>();

                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        List<string> addressLine = line.Split(", ").ToList();

                        addresses.Add(new Address(addressLine));
                    }
                }

                addressValidation.Addresses = addresses;
                return true;

            }
            catch (IOException exc)
            {
                return false;
            }
        }

        /// <summary>
        /// Writes all validated address string to output file
        /// </summary>
        /// <param name="addressValidation">The object that contains a list of validated address strings</param>
        /// <returns>A boolean that if true, means the operation was succesful</returns>
        public bool WriteOutputFile(AddressValidation addressValidation)
        {
            try
            {
                File.WriteAllText(outputFilePath, string.Empty);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {

                    foreach (string line in addressValidation.ValidatedAddresses)
                    {
                        writer.WriteLine(line);
                    }
                }

                return true;

            }
            catch (IOException exc)
            {
                return false;
            }

        }

        public FileAccess()
        {

        }

    }
}
