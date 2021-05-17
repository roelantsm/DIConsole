using GanzenBoardGame.Application.Factory;
using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.Modals.Rondes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public class RoundService : IRoundService
    {
        private readonly RondeFactory _rondeFactory;

        public RoundService(RondeFactory rondeFactory)
        {
            _rondeFactory = rondeFactory;
        }

        public int[] PlayRound(int aantalSpelers, Ronde ronde)
        {

            int[] gegooidDezeRonde = new int[aantalSpelers];

            for (int i = 0; i < aantalSpelers; i++)
            {
                gegooidDezeRonde[i] = ronde.GooiDobbelStenen();
            }
            return gegooidDezeRonde;
        }

        public Ronde CreateRound(int currentRonde)
        {
            string RoundTypeString;
            switch (currentRonde)
            {
                case 0:
                    RoundTypeString = "FirstRonde";
                    break;
                default:
                    RoundTypeString = "CasualRonde";
                    break;
            }
            return _rondeFactory.Create(RoundTypeString, currentRonde);
        }
    }
}
