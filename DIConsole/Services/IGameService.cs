using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.Modals.Rondes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public interface IGameService
    {
        void PlayNewRound(ref List<Player> Spelers, ref List<Ronde> Rondes, ref GanzenBoard PlayerBoard);
    }
}
