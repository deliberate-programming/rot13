using System.Linq;
using rot13.adapters;
using Xunit;

namespace rot13.tests
{
    public class FilesystemProvider_tests
    {
        [Fact]
        public void EnumerateSourcefiles()
        {
            var sut = new FilesystemProvider();

            var result = sut.EnumerateSourcefiles(new[] {"../../samples/unencrypted"}, new[] {".txt", ".md"});
            
            Assert.Equal(3, result.Count());
        }
    }
}