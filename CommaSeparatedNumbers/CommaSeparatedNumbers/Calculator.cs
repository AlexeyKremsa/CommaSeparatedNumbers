using System;
using System.Collections.Generic;
using System.Linq;

namespace CommaSeparatedNumbers
{
    public class Calculator : ICalculator
    {
        public int GetSum(string userInput)
        {
            int sum = 0;

            var parsedCollection = ParseInput(userInput);

            foreach (var item in parsedCollection)
            {
                int value;
                var isValid = int.TryParse(item, out value);

                if (!isValid)
                {
                    throw new FormatException(String.Format("{0} is not the correct format", item));
                }

                sum += value;
            }

            return sum;
        }

        public bool IsInputValid(string userInput)
        {
            var parsedCollection = ParseInput(userInput);

            foreach (var item in parsedCollection)
            {
                int value;
                var isValid = int.TryParse(item, out value);

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }

        private IEnumerable<string> ParseInput(string userInput)
        {
            return userInput.Split(',').Where(x => !String.IsNullOrEmpty(x));
        }
    }

}
