using System;
using System.Linq;

namespace rot13
{
    internal class ROT13
    {
        // Source: https://en.wikipedia.org/wiki/ROT13
        private const string INPUT = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string OUTPUT = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";


        public static string EncryptDecrypt(string text)
            => new string(text.Select(Map).ToArray());

        static char Map(char c) {
            var i = INPUT.IndexOf(c);
            return i < 0 ? c : OUTPUT[i];
        }
    }
}