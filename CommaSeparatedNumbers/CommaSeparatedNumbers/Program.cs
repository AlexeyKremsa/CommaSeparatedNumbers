using System;

namespace CommaSeparatedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //avoided IoC just to simplify this application
            ICalculator calculator = new Calculator();
            const string INPUT_NUMBERS_MSG = "Please, input comma separated integer numbers";
            const string EXIT_COMMAND = "exit";

            try
            {
                Console.WriteLine(INPUT_NUMBERS_MSG);
                string userInput = Console.ReadLine();

                while (userInput!= null && userInput.ToLower() != EXIT_COMMAND)
                {

                    if (calculator.IsInputValid(userInput))
                    {
                        Console.WriteLine("Sum = {0}", calculator.GetSum(userInput));
                    }
                    else
                    {
                        Console.WriteLine("Input is nod valid. Please try again.");
                    }

                    Console.WriteLine("\n" + INPUT_NUMBERS_MSG);
                    userInput = Console.ReadLine();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
