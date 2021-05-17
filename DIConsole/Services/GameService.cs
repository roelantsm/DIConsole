using GanzenBoardGame.Application.Logging;
using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.Modals.Locations;
using GanzenBoardGame.Application.Modals.Rondes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public class GameService : IGameService
    {

        public List<Player> Spelers { get; set; } = new List<Player>();
        public List<Ronde> Rondes { get; set; } = new List<Ronde>();
        public GanzenBoard PlayerBoard { get; set; }

        private readonly IRoundService _roundService;
        private readonly ILogger _logger;



        public GameService(
            IRoundService roundService, 
            GanzenBoardGame.Application.Logging.ILogger logger)
        {
            _roundService = roundService;
            _logger = logger;
        }

        public void PlayNewRound(ref List<Player> spelersRef, ref List<Ronde> rondeRef, ref GanzenBoard playerBoarRef)
        {
            Spelers = spelersRef;
            Rondes = rondeRef;
            PlayerBoard = playerBoarRef;

            _logger.LogInformationMessage($"RONDE: {Rondes.Count}");
            var ronde = _roundService.CreateRound(Rondes.Count);
            Rondes.Add(ronde);
            var dezeRondeGegooid = _roundService.PlayRound(Spelers.Count, ronde);

            for (int i = 0; i < dezeRondeGegooid.Length; i++)
            {

                if (Rondes.Count == 1)
                {
                    Spelers[i].Pion.Locatie = new CasualLocatie(0);
                }

                if (Spelers[i].turnsToSkip >= 0)
                {
                    _logger.LogInformationMessage($"Speler { Spelers[i].Name} mag geen beurt maken");
                    Spelers[i].turnsToSkip = Spelers[i].turnsToSkip - 1;

                }
                else
                {
                    _logger.LogInformationMessage($"Speler { Spelers[i].Name} gooide { dezeRondeGegooid[i] }");

                    _logger.LogInformationMessage($"Speler zijn vorige positie: {Spelers[i].Pion.Locatie.SpelersVak}");

                    if (Spelers[i].Pion.Locatie.SpelersVak + dezeRondeGegooid[i] <= GanzenBoard.AantalValkjes)
                    {
                        Spelers[i].Pion.Locatie = PlayerBoard.Spelboardvakjes.Where(x => x.SpelersVak == Spelers[i].Pion.Locatie.SpelersVak + dezeRondeGegooid[i]).First();
                    }
                    else
                    {
                        var aantalTerug = Spelers[i].Pion.Locatie.SpelersVak + dezeRondeGegooid[i] - GanzenBoard.AantalValkjes;
                        Spelers[i].Pion.Locatie = PlayerBoard.Spelboardvakjes.Where(x => x.SpelersVak == GanzenBoard.AantalValkjes - aantalTerug).First();
                    }
                    _logger.LogInformationMessage($"Speler is aangekomen op vak:  {Spelers[i].Pion.Locatie.SpelersVak}");

                    IsSpelerOpeenGoozeBeland(i, dezeRondeGegooid[i]);

                    Spelers[i] = Spelers[i].Pion.Locatie.OpDezeSoortLocatieAangekomen(Spelers[i], PlayerBoard);

                    _logger.LogInformationMessage("");
                }
            }
            spelersRef = Spelers;
            rondeRef = Rondes;
            playerBoarRef = PlayerBoard;
        }


        public void IsSpelerOpeenGoozeBeland(int indexSpeler, int aantalGegooid)
        {

            if (Spelers[indexSpeler].Pion.Locatie.IsSpaceWithGoose)
            {
                _logger.LogInformationMessage("Op een gooze beland");
                if (Spelers[indexSpeler].Pion.Locatie.SpelersVak + aantalGegooid <= GanzenBoard.AantalValkjes)
                {
                    Spelers[indexSpeler].Pion.Locatie = PlayerBoard.Spelboardvakjes.Where(x => x.SpelersVak == Spelers[indexSpeler].Pion.Locatie.SpelersVak + aantalGegooid).First();
                }

                else
                {
                    var aantalTerug = Spelers[indexSpeler].Pion.Locatie.SpelersVak + aantalGegooid - GanzenBoard.AantalValkjes;
                    Spelers[indexSpeler].Pion.Locatie = PlayerBoard.Spelboardvakjes.Where(x => x.SpelersVak == GanzenBoard.AantalValkjes - aantalTerug).First();
                }

                _logger.LogInformationMessage($"Niuewe positie {Spelers[indexSpeler].Pion.Locatie.SpelersVak}");
                IsSpelerOpeenGoozeBeland(indexSpeler, aantalGegooid);
            }
        }
    }
}
