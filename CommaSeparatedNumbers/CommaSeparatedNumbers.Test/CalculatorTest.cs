using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace CommaSeparatedNumbers.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        ICalculator _calculator;

        [SetUp]
        public void Initialize()
        {
            _calculator = new Calculator();
        }

        [TestCase("1,2,3")]
        [TestCase("1,,12   ,8,9,")]
        public void IsInputValid_ValidInput_ReturnsTrue(string input)
        {
            var result = _calculator.IsInputValid(input);

            Assert.IsTrue(result);
        }

        [TestCase("1;2")]
        [TestCase("1,5 6,10")]
        [TestCase("1,2,a,5")]
        public void IsInputValid_InvalidInput_ReturnsFalse(string input)
        {
            var result = _calculator.IsInputValid(input);

            Assert.IsFalse(result);
        }

        [TestCase("1,2,3", ExpectedResult = 6)]
        [TestCase("-2,-2", ExpectedResult = -4)]
        public int GetSum_CommaSeparatedIntegers_CorrectValue(string input)
        {
            return _calculator.GetSum(input);
        }

        [TestCase("1,2,a,5")]
        public void GetSum_InvalidInput_ThrowsException(string input)
        {
            ExceptionAssert.Throws<FormatException>(() => _calculator.GetSum(input));
        }
    }
}
