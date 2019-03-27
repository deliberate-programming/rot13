using System;
using System.Collections.Generic;
using rot13.adapters;
using rot13.domain;

namespace rot13.integration
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

        private void EncryptFile(string fn) {
            var text = _filesystem.LoadText(fn);
            var encryptedText = ROT13.EncryptDecrypt(text);
            _filesystem.ReplaceOriginalWithProcessed(fn, encryptedText);
            this.OnFileProcessed(fn);
        }


        public event Action<string> OnFileProcessed;
    }
}