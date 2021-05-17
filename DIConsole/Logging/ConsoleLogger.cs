using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Logging
{
    class ConsoleLogger : ILogger
    {
        public void LogInformationMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void LogErrorMessage(string message)
        {
            LogInformationMessage($"ERROR: { message }");
        }
    }
}
