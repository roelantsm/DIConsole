using DIConsole;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Logging
{
    class LogLogger : GanzenBoardGame.Application.Logging.ILogger
    {
        private readonly ILogger<Program> logger;

        public LogLogger(ILogger<Program> logger)
        {
            this.logger = logger;
        }

        public void LogInformationMessage(string message)
        {
            logger.LogInformation(message);
        }

        public void LogErrorMessage(string message)
        {
            logger.LogError(message);
        }
    }
}
