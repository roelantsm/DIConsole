using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.validatie
{
    public interface IDateTimeValidatie
    {
        DateTime ParseStringToDatetime(String StringToParseToDateTime);
    }
}
