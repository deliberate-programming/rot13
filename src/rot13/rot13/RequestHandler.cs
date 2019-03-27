using System;
using System.Collections;
using System.Collections.Generic;

namespace rot13
{
    internal class RequestHandler
    {
        public event Action<string> OnFileProcessed;
        
        
        public int Encrypt(IEnumerable<string> sources)
        {
            return 0;
        }
    }

    internal class FilesystemProvider
    {
        
    }

    internal class ROT13
    {
        public string EncryptDecrypt(string text)
        {
            throw new NotImplementedException();
        }
    }
}