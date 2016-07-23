namespace CommaSeparatedNumbers
{
    public interface ICalculator
    {
        int GetSum(string userInput);
        bool IsInputValid(string userInput);
    }
}
