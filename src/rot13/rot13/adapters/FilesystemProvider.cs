using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rot13
{
    internal class FilesystemProvider
    {
        public IEnumerable<string> EnumerateSourcefile(IEnumerable<string> sources) {
            var allFilenames = EnumerateAllFiles(sources);
            return SelectRelevantFiles(allFilenames);
        }

        private IEnumerable<string> EnumerateAllFiles(IEnumerable<string> sources) {
            return sources.SelectMany(EnumerateSource);

            IEnumerable<string> EnumerateSource(string source) {
                if (File.Exists(source)) return new[] {source};
                if (Directory.Exists(source) is false) return new string[0];
                return Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);
            }

        }

        private IEnumerable<string> SelectRelevantFiles(IEnumerable<string> filenames)
            => filenames.Where(fn => fn.ToLower().EndsWith(".txt") || fn.ToLower().EndsWith(".md"));

        
        public string LoadText(string filename) => File.ReadAllText(filename);

        
        public void ReplaceOriginalWithProcessed(string originalFilename, string text) {
            var processedFilename = originalFilename;
            if (processedFilename.ToLower().EndsWith(".encrypted"))
                processedFilename = Path.GetFileNameWithoutExtension(processedFilename);
            else
                processedFilename += ".encrypted";
            
            File.WriteAllText(processedFilename, text);
            
            if (File.Exists(originalFilename))
                File.Delete(originalFilename);
        }
    }
}