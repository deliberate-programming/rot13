using Xunit;

namespace rot13.tests
{
    public class ROT13_tests
    {
        [Theory]
        [InlineData("Hello!", "Uryyb!")]
        [InlineData("", "")]
        [InlineData("A\nB\rC\tD E", "N\nO\rP\tD E")]
        public void Encrypt()
        {
            
        }
    }
}