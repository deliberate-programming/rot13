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
            int n;
            switch (command.Command) {
                case Config.Commands.Encrypt:
                    n = _requestHandler.Encrypt(command.Sources);
                    break;
                case Config.Commands.Decrypt:
                    n = _requestHandler.Decrypt(command.Sources);
                    break;
            }
            _display.LogNumberOfFilesProcessed(n);
        }
    }
}