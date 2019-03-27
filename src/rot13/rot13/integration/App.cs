using System;
using rot13.adapters;

namespace rot13.integration
{
    class App
    {
        private readonly Config _config;
        private readonly RequestHandler _requestHandler;
        private readonly Display _display;

        public App(Config config, RequestHandler requestHandler, Display display) {
            _config = config;
            _requestHandler = requestHandler;
            _display = display;

            _requestHandler.OnFileProcessed += _display.LogFileProcessed;
        }

        public void Run() {
            var command = _config.Parse();
            switch (command.Command) {
                case Config.Commands.Encrypt:
                    var n = _requestHandler.Encrypt(command.Sources);
                    _display.LogNumberOfFilesProcessed(n);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}