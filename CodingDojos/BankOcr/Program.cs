using System;

namespace BankOcr
{
    //You work for a bank, which has recently purchased an ingenious machine
    //to assist in reading letters and faxes sent in by branch offices.
    //The machine scans the paper documents, and produces a file with
    //a number of entries which each look like this:

    //  _  _     _  _  _  _  _
    //| _| _||_||_ |_   ||_||_|
    //||_  _|  | _||_|  ||_| _|
    
    //Each entry is 4 lines long, and each line has 27 characters.
    //The first 3 lines of each entry contain an account number written
    //using pipes and underscores, and the fourth line is blank.
    //Each account number should have 9 digits, all of which should
    //be in the range 0-9. A normal file contains around 500 entries.
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var inputValidator = new InputValidator();
            var inputFormatter = new InputFormatter();

            var input = fileReader.Read("input.txt");
            if (inputValidator.IsValid(input))
            {
                var formattedInput = inputFormatter.Format(input);
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}