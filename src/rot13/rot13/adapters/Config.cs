using System;
using System.Collections.Generic;
using System.Linq;

namespace rot13.adapters
{
    internal class Config
    {
        private readonly string[] _args;

        public enum Commands {
            Encrypt,
            Decrypt
        }
        
        
        public Config(string[] args) {
            _args = args;
        }


        public (Commands Command, IEnumerable<string> Sources) Parse() {
            return (ParseCommand(), ParseSources());

            Commands ParseCommand() {
                switch (_args[0].ToLower()) {
                    case "encrypt":
                    case "e":
                        return Commands.Encrypt;
                    case "decrypt":
                    case "d":
                        return Commands.Decrypt;
                }
                throw new InvalidOperationException($"Unknown command: {_args[0]}!");
            }

            IEnumerable<string> ParseSources() => _args.Skip(1);
        }
    }
}