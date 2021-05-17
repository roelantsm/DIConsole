using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBord2.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public Pion Pion { get; set; }

        public static int maxAantalPlayers = 4;


        public void SpelerKiestEenPion(int spelersId, int PionId)
        {

        }
    }
}
