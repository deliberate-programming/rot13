using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace rot13
{
    internal class FilesystemProvider
    {
        public IEnumerable<string> EnumerateSourcefile(IEnumerable<string> sources)
        {
            var allFilenames = EnumerateAllFiles(sources);
            return 
        }

        public string LoadText(string filename) => File.ReadAllText(filename);

        public void  Store(string filename, string text)
        {
            // store
            // delete original
            throw new NotImplementedException();
        }
    }
}