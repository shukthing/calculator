namespace Calculator
{
    public class SumStrategy : IOperationStrategy
    {
        public bool IsActive(char symbol)
        {
            return '+'.Equals(symbol);
        }

        public int Perform(int first, int second)
        {
            return first + second;
        }
    }
}