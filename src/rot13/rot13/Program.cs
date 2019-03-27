using System;

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

    class App
    {
        private readonly Config _config;
        private readonly RequestHandler _requestHandler;
        private readonly Display _display;

        public App(Config config, RequestHandler requestHandler, Display display) {
            _config = config;
            _requestHandler = requestHandler;
            _display = display;
        }

        public void Run()
        {
            var command = _config.
        }
    }
}