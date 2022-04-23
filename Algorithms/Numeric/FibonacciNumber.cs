namespace Algorithms.Numeric
{
    public static class FibonacciNumber
    {
        public static int GetFibonacciNumber(int index)
        {
            switch (index)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return GetFibonacciNumber(index - 1) + GetFibonacciNumber(index - 2);
            }
        }
    }
}