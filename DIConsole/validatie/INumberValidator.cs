using GanzenBoardGame.Application.Logging;
using GanzenBoardGame.Application.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.validatie
{
    public interface INumbervalidator
    {
        bool SpelersAantalValidate(string gekozenNumber, int maxAantalSpeler, int minimumAantalSpelers);
        bool ParseStringToInt(String StringToParseToInt);
    }
}
