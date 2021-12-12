using AddressValidator.Operations;
using AddressValidator.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressValidator
{

    /// <summary>
    /// This class contains all interactions with the user
    /// </summary>
    public class UserInterface
    {
        FileAccess file = new FileAccess();
        AddressValidation validation = new AddressValidation();

        public void ApplicationStart()
        {
            bool readSuccess = file.ReadInputFile(validation);

            if (readSuccess)
            {
                validation.ValidateAddresses();
                bool writeSuccess = file.WriteOutputFile(validation);

                if (writeSuccess)
                {
                    Console.WriteLine("Address vaildation completed");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("There was an error writing the output file.");
                }
            }
            else
            {
                Console.WriteLine("There was an error reading the input file.");
            }

        }
    }
}
