using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBord2.Models
{
    public class Game
    {
        public List<Player> Spelers { get; set; }
        public List<CasualRonde> Rondes { get; set; }
        public GanzenBoard PlayerBoard { get; set; }

        public Game(GanzenBoardGame.Application.Logging logger)
        {

        }

        public void CreateSpelers()
        {
        }

        public void StartNewGame()
        {
            // zijn er al spelers

            // vorige spelers gebruiken
        }

        public void Endgame()
        {
        }

    }
}
