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
        
        
        public int Encrypt(IEnumerable<string> sources) {
            var filenames = _filesystem.EnumerateSourcefile(sources);
            return EncryptFiles(filenames);
        }

        private int EncryptFiles(IEnumerable<string> filenames) {
            var n = 0;
            foreach (var fn in filenames) {
                EncryptFile(fn);
                n++;
            }
            return n;
        }

        private void EncryptFile(string fn)
        {
            throw new NotImplementedException();
        }


        public event Action<string> OnFileProcessed;
    }
}