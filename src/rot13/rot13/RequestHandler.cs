using System;
using System.Collections;
using System.Collections.Generic;

namespace rot13
{
    internal class RequestHandler
    {
        private readonly FilesystemProvider _filesystem;

        public RequestHandler(FilesystemProvider filesystem) {
            _filesystem = filesystem;
        }
        
        
        public int Encrypt(IEnumerable<string> sources)
        {
            var filenames = _filesystem.EnumerateSourcefile(sources);
            
        }
        
        
        public event Action<string> OnFileProcessed;
    }
}