using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.UserInput
{
    public class ConsoleInput : IConsoleInput
    {
        public string ReadUserInput()
        {
            return Console.ReadLine();
        }
    }
}
