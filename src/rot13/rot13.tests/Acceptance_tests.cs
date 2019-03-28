using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using rot13.adapters;
using rot13.integration;
using Xunit;

namespace rot13.tests
{
    public class Acceptance_tests
    {
        [Fact]
        public void Encrypt()
        {
            CopyFiles("../../samples/unencrypted", "testencrypt");
            
            var sut = new RequestHandler(new FilesystemProvider());
            var filesProcessed = new List<string>();
            sut.OnFileProcessed += filename => filesProcessed.Add(Path.GetFileName(filename));

            var result = sut.Encrypt(new[] {"testencrypt"});
            
            Assert.Equal(result, 3);
            
            filesProcessed.Sort();
            Assert.Equal(new[]{"humptydumpty.txt", "marys lamb.txt", "onering.md"}, filesProcessed);

            var encryptedFilenames = Directory.GetFiles("testencrypt", "*.*", SearchOption.AllDirectories);
            Assert.Equal(3, encryptedFilenames.Length);
            Assert.True(encryptedFilenames.All(fn => fn.EndsWith(".encrypted")));
        }
        
        [Fact]
        public void Decrypt()
        {
            CopyFiles("../../samples/encrypted", "testdecrypt");
            
            var sut = new RequestHandler(new FilesystemProvider());
            var filesProcessed = new List<string>();
            sut.OnFileProcessed += filename => filesProcessed.Add(Path.GetFileName(filename));

            var result = sut.Decrypt(new[] {"testdecrypt"});
            
            Assert.Equal(result, 3);
            
            filesProcessed.Sort();
            Assert.Equal(new[]{"humptydumpty.txt.encrypted", "marys lamb.txt.encrypted", "onering.md.encrypted"}, filesProcessed);

            var decryptedFilenames = Directory.GetFiles("testdecrypt", "*.*", SearchOption.AllDirectories).ToList();
            decryptedFilenames.Sort();
            Assert.Equal(new[]{"humptydumpty.txt", "marys lamb.txt", "onering.md"}, decryptedFilenames);
        }


        static void CopyFiles(string sourcePath, string destinationPath)
        {
            if (Directory.Exists(destinationPath))
                Directory.Delete(destinationPath, true);
            
            var filenames = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
            foreach (var fn in filenames) {
                var destFilename = fn.Replace(sourcePath, destinationPath);
                Directory.CreateDirectory(Path.GetDirectoryName(destFilename));
                File.Copy(fn, destFilename, true);
            }
        }
    }
}