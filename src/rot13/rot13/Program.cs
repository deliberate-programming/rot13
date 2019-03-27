using rot13.adapters;
using rot13.integration;

namespace rot13
{
    internal class Program
    {
        public static void Main(string[] args) {
            var config = new Config(args);
            var display = new Display();
            var filesystem = new FilesystemProvider();
            var requestHandler = new RequestHandler(filesystem);
            
            var app = new App(config, requestHandler, display);
            
            app.Run();
        }
    }
}