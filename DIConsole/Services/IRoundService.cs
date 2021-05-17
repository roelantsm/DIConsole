using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.Modals.Rondes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public interface IRoundService
    {
        Ronde CreateRound(int currentRonde);
        int[] PlayRound(int aantalSpelers, Ronde ronde);
    }
}
