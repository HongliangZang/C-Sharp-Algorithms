using Algorithms.Numeric;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    public class FibonacciNumberTests
    {
        [Fact]
        public void Should_return_zero()
        {
            var result = FibonacciNumber.GetFibonacciNumber(0);
            Assert.True(result.Equals(0));
        }
        
        [Fact]
        public void Should_return_one()
        {
            var result = FibonacciNumber.GetFibonacciNumber(1);
            Assert.True(result.Equals(1));
        }
        
        [Fact]
        public void Should_return_one_for_position_two()
        {
            var result = FibonacciNumber.GetFibonacciNumber(2);
            Assert.True(result.Equals(1));
        }
        
        
        [Fact]
        public void Should_return_correct_value_for_position_eight()
        {
            var result = FibonacciNumber.GetFibonacciNumber(8);
            Assert.True(result.Equals(21));
        }
    }
}