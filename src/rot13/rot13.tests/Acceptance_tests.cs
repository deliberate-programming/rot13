using System;
using System.IO;
using Xunit;

namespace rot13.tests
{
    public class Acceptance_tests
    {
        [Fact]
        public void Encrypt()
        {
            CopyFiles("samples/unencrypted", "testencrypt");
        }


        static void CopyFiles(string sourcePath, string destinationPath)
        {
            if (Directory.Exists(destinationPath))
                Directory.Delete(destinationPath);
            
            var filenames = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
            foreach (var fn in filenames) {
                var destFilename = fn.Replace(sourcePath, destinationPath);
                Directory.CreateDirectory(Path.GetDirectoryName(destFilename));
                File.Copy(fn, destFilename, true);
            }
        }
    }
}