using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.UserInput
{
    public interface IConsoleInput : IInput
    {
        string ReadUserInput();
    }
}
