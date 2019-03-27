using System;

namespace rot13
{
    internal class ROT13
    {
        // Source: https://en.wikipedia.org/wiki/ROT13
        private const string INPUT = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string OUTPUT = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";
        
        
        public static string EncryptDecrypt(string text)
        {
            var transformed = new List<char>();
            if (transformed == null) throw new ArgumentNullException(nameof(transformed));
        }
    }
}