using System.Collections.Generic;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Theory, DefaultAutoData]
        public void Calculate_GivenSumStrategy_ReturnSumOfTwoNumbers(ILogger logger)
        {
            var calc = new Calculator(new List<IOperationStrategy>(){new SumStrategy()}, logger);

            var result = calc.Calculate('+', 2, 1);

            Assert.Equal(3, result);
        }
    }
}
