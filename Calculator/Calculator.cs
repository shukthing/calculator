using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        private readonly IEnumerable<IOperationStrategy> _operations;
        private readonly ILogger _logger;

        public Calculator(IEnumerable<IOperationStrategy> operations, ILogger logger)
        {
            _operations = operations;
            _logger = logger;
        }

        public int Calculate(char operation, int first, int second)
        {
            foreach(var strategy in _operations)
            {
                if(strategy.IsActive(operation))
                {
                    var result = strategy.Perform(first, second);
                    _logger.Log($"result = {result}.");
                    return result;
                }
            }

            _logger.Log("No matching operation found.");
            return 0;
        }
    }
}
