using Calculator.Tests.Models;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Theory, DefaultAutoData]
        public void Calculate_GivenSumStrategy_ReturnSumOfTwoNumbers(ILogger logger)
        {
            //implement factory pattern so that it doesnt need to repeat in every test, also to make it flexible to adapt when the parameter changed
           /* var opr = new List<IOperationStrategy>();
            opr.Add(new SumStrategy());
            var test = new Calculator(opr, logger);*/

            var calc = new Calculator(new List<IOperationStrategy>() { new SumStrategy() }, logger);

            var result = calc.Calculate('+', 2, 1);

            Assert.Equal(3, result);
            logger.Received(1).Log($"result = {result}.");
            // TODO: Assert that ILogger.Log called with "result = {result}."
        }

        [Theory, DefaultAutoData]
        public void Calculate_GivenInvalidOperation_ReturnsNotFoundWithErrorInfo(ILogger logger)
        {
            var calc = new Calculator(new List<IOperationStrategy>() { new SumStrategy() }, logger);

            calc.Calculate('-', 5, 3);

            logger.Received(1).Log(LogResponse.NoMatchFound);
            // TODO: Assert that ILogger.Log called with "No matching operation found."
        }

        [Theory, DefaultAutoData]
        public void Calculate_GivenNullStrategy_ReturnsNotFoundWithErrorInfo(ILogger logger)
        {
            var calc = new Calculator(new List<IOperationStrategy>(), logger);

            calc.Calculate('+', 5, 3);

            logger.Received(1).Log(LogResponse.NoMatchFound);
            // TODO: Assert that ILogger.Log called with "No matching operation found."
        }
    }
}
