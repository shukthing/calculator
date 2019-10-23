namespace Calculator
{
    public interface IOperationStrategy
    {
        bool IsActive(char symbol);

        int Perform(int first, int second);
    }
}