using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }


        [Fact]
        public void CanFormatTwoItems()
        {
            Assert.Equal("hello and world", Algorithms.FormatSeparators("hello", "world"));
        }

        [Fact]
        public void CanFormatOneItem()
        {
            Assert.Equal("only", Algorithms.FormatSeparators("only"));
        }

        [Fact]
        public void CanFormatEmpty()
        {
            Assert.Equal(string.Empty, Algorithms.FormatSeparators());
        }
    }
}
