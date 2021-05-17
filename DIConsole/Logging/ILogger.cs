using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Logging
{
    public interface ILogger
    {
        void LogInformationMessage(string message);
        void LogErrorMessage(string message);
    }
}
