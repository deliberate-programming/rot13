using System;

namespace rot13
{
    internal class Display
    {
        public void LogFileProcessed(string filename)
            => Console.WriteLine(filename);

        public void LogNumberOfFilesProcessed(int n)
            => Console.WriteLine($"{n} file(s) processed");
    }
}