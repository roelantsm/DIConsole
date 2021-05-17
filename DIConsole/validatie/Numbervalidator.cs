using GanzenBoardGame.Application.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.validatie
{
    public class Numbervalidator : INumbervalidator
    {
        private readonly ILogger _logger;

        public Numbervalidator(ILogger logger)
        {
            this._logger = logger;
        }

        public bool ParseStringToInt(String StringToParseToInt)
        {
            return int.TryParse(StringToParseToInt, out _);
        }

        public bool SpelersAantalValidate(String StringToParseToInt, int maxAantalSpeler, int minimumAantalSpelers)
        {
            int.TryParse(StringToParseToInt, out int aantalSpelers); // returns default 0 if cant be parsed
            return aantalSpelers <= maxAantalSpeler && aantalSpelers >= minimumAantalSpelers;
        }
    }
}
