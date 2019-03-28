using System.IO;
using System.Linq;
using rot13.adapters;
using Xunit;

namespace rot13.tests
{
    public class FilesystemProvider_tests
    {
        [Fact]
        public void EnumerateSourceFiles()
        {
            var sut = new FilesystemProvider();

            var result = sut.EnumerateSourcefiles(new[] {"../../samples/unencrypted"}, new[] {".txt", ".md"});
            
            Assert.Equal(3, result.Count());
        }


        [Fact]
        public void __SelectRelevantFiles()
        {
            var result = FilesystemProvider.SelectRelevantFiles(new[] {"a.md", "b.txt"}, new[] {"TXT"});
            Assert.Equal(new[]{"b.txt"}, result.ToArray());
        }


        [Fact]
        public void ReplaceTxtWithEncrypted()
        {
            var sourceFilename = "u.txt";
            File.WriteAllText(sourceFilename, "unencrypted");
            
            var sut = new FilesystemProvider();
            
            sut.ReplaceOriginalWithProcessed(sourceFilename, "encrypted");
            
            Assert.Equal("encrypted", File.ReadAllText(sourceFilename + ".encrypted"));
            Assert.False(File.Exists(sourceFilename));
        }
    }
}