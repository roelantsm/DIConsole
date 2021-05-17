using GanzenBoardGame.Application.Factory;
using GanzenBoardGame.Application.Logging;
using GanzenBoardGame.Application.Modals.Locations;
using GanzenBoardGame.Application.Modals.Rondes;
using GanzenBoardGame.Application.Services;
using GanzenBoardGame.Application.UserInput;
using GanzenBoardGame.Application.validatie;
using GanzenBoardGame.SharedKernal.StringHelperFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanzenBoardGame.Application.Modals
{
    public class Game
    {
        public List<Player> Spelers { get; set; } = new List<Player>();
        public List<Ronde> Rondes { get; set; } = new List<Ronde>();
        public GanzenBoard PlayerBoard { get; set; }


        private readonly ILogger _logger;
        private readonly IConsoleInput _consoleInput;
        INumbervalidator _numberValidator;
        IStringValidatie _stringValidatie;
        IDateTimeValidatie _dateTimeValidatie;
        IGameBoardService _gameBoardService;
        IPlayerService _playerService;
        IPionService _pionService;
        IRoundService _roundService;

        public Game(GanzenBoardGame.Application.Logging.ILogger logger,
            IConsoleInput consoleInput,
            INumbervalidator validator,
            IStringValidatie stringValidatie,
            IDateTimeValidatie dateTimeValidatie,
            IGameBoardService gameBoardService,
            IPlayerService playerService,
            IPionService pionService,
            IRoundService roundService
            )
        {
            _logger = logger;
            _consoleInput = consoleInput;
            _numberValidator = validator;
            _stringValidatie = stringValidatie;
            _dateTimeValidatie = dateTimeValidatie;
            _gameBoardService = gameBoardService;
            _playerService = playerService;
            _pionService = pionService;
            _roundService = roundService;
        }

        // Setup
        public void SetupNewGame()
        {
            _logger.LogInformationMessage("Setting up a new game");

            Spelers = _playerService.SetupNewSpelers();
            PlayerBoard = _gameBoardService.GeneratePlayerBoard(GanzenBoard.AantalValkjes);
            Spelers = _pionService.SpelersKiezenEenPion(Spelers);
        }

        // playing
        public void PlayGame()
        {
            bool gameHasEnded = false;
            while (!gameHasEnded)
            {
                PlayNewRound();
                foreach (var speler in Spelers)
                {
                    if (speler.Pion.Locatie.SpelersVak == GanzenBoard.AantalValkjes)
                    {
                        gameHasEnded = true;
                    }
                }
            }
        }

        // TO DO
        // bug starpositie 9, isOpzGoozeBeland
        // cleanup Game.cs

        public void PlayNewRound()
        {

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

                if (Spelers[i].turnsToSkip > 0)
                {
                    _logger.LogInformationMessage($"Speler { Spelers[i].Name} mag geen beurt maken");
                    Spelers[i].turnsToSkip = Spelers[i].turnsToSkip - 1;
                    continue;

                }

                if (Spelers[i].Pion.Locatie.SpelersVak == InnLocatie.InnLocation)
                {
                    if (!Spelers.Where(x => x.Pion.Locatie.SpelersVak == InnLocatie.InnLocation && x.Id != Spelers[i].Id).Any())
                    {
                        _logger.LogInformationMessage($"Speler { Spelers[i].Name} staat als enige op de well en mag geen beurt maken");
                        continue;
                    }
                }

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
