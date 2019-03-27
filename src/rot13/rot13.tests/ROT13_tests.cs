using rot13.domain;
using Xunit;

namespace rot13.tests
{
    public class ROT13_tests
    {
        [Theory]
        [InlineData("Hello!", "Uryyb!")]
        [InlineData("", "")]
        [InlineData("A\nB\rC\tD E", "N\nO\rP\tQ R")]
        public void Encrypt(string text, string expected)
        {
            var result = ROT13.EncryptDecrypt(text);
            Assert.Equal(expected, result);
        }
    }
}