using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rot13.adapters
{
    internal class FilesystemProvider
    {
        public IEnumerable<string> EnumerateSourcefiles(IEnumerable<string> sources, string[] relevantExtensions) {
            var allFilenames = EnumerateAllFiles(sources);
            return SelectRelevantFiles(allFilenames, relevantExtensions);
        }

        private static IEnumerable<string> EnumerateAllFiles(IEnumerable<string> sources) {
            return sources.SelectMany(EnumerateSource);

            IEnumerable<string> EnumerateSource(string source) {
                if (File.Exists(source)) return new[] {source};
                if (Directory.Exists(source) is false) return new string[0];
                return Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);
            }

        }

        internal static IEnumerable<string> SelectRelevantFiles(IEnumerable<string> filenames, string[] relevantExtensions) {
            var relevantExtensions_ = new HashSet<string>(Normalize(relevantExtensions));
            return filenames.Where(fn => relevantExtensions_.Contains(Path.GetExtension(fn).ToLower()));

            IEnumerable<string> Normalize(IEnumerable<string> extensions)
                => extensions.Select(x => x.StartsWith(".") ? x : "." + x)
                             .Select(x => x.ToLower());
        }


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