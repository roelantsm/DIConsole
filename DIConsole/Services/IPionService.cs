using GanzenBoardGame.Application.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public interface IPionService
    {
        List<Player> SpelersKiezenEenPion(List<Player> spelers);
    }
}
