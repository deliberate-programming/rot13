using System.Collections;
using System.Collections.Generic;

namespace rot13
{
    internal class Config
    {
        private readonly string[] _args;

        public enum Commands {
            Encrypt,
            Decrypt
        }
        
        
        public Config(string[] args)
        {
            _args = args;
        }


        (Commands Command, IEnumerable<string> Sources) Parse()
        {
            
        }
    }
}