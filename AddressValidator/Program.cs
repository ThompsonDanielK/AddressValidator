using System;

namespace AddressValidator
{
    /// <summary>
    /// This class instantiates UserInterface and starts the process.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            userInterface.ApplicationStart();
        }
    }
}
