using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Modals
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public Pion Pion { get; set; } = new Pion();

        public int turnsToSkip = 0;

        public static int maxAantalPlayers = 4;


        public void SpelerKiestEenPion(int spelersId, int PionId)
        {

        }
    }
}
