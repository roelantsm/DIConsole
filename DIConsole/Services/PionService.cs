using GanzenBoardGame.Application.Logging;
using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.UserInput;
using GanzenBoardGame.Application.validatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public class PionService : IPionService
    {
        private readonly ILogger _logger;
        private readonly IConsoleInput _consoleInput;
        private readonly IStringValidatie _stringValidatie;

        public PionService(
            GanzenBoardGame.Application.Logging.ILogger logger,
            IStringValidatie stringValidatie,
            IConsoleInput consoleInput)
        {
            _logger = logger;
            _consoleInput = consoleInput;
            _stringValidatie = stringValidatie;

        }

        public List<Player> SpelersKiezenEenPion(List<Player> spelers)
        {
            var alleMogelijkePionnen = Pion.mogelijkePionnen;
            var alleGekozenPionnen = new List<Pion>();

            _logger.LogInformationMessage("Spelers kiezen een pion");

            for (int i = 0; i < spelers.Count; i++)
            {
                List<Pion> enkelMogelijkePionnen = alleMogelijkePionnen.Except(alleGekozenPionnen).ToList();

                ShowAllPionnen(enkelMogelijkePionnen);
                bool SpelerHeeftNuEenGeldigePion = false;
                while (!SpelerHeeftNuEenGeldigePion)
                {
                    _logger.LogInformationMessage($"Speler {spelers[i].Name} kiest een pion");
                    var gekozenPionInput = _consoleInput.ReadUserInput();
                    var isGelukt = _stringValidatie.SpelersKiestEenGeldigePion(gekozenPionInput, enkelMogelijkePionnen);

                    if (isGelukt)
                    {
                        int.TryParse(gekozenPionInput, out int parsedIdFromPion);
                        Pion gekozenPion = enkelMogelijkePionnen.First(x => x.Id == parsedIdFromPion);
                        spelers[i].Pion = gekozenPion;
                        alleGekozenPionnen.Add(gekozenPion);
                        _logger.LogInformationMessage($"Speler {spelers[i].Name} kiest pion {gekozenPion.ToString()}");
                        SpelerHeeftNuEenGeldigePion = true;
                    }
                    else
                    {
                        _logger.LogErrorMessage($"Speler {spelers[i].Name} koos geen geldige pion");
                    }
                }
            }
            return spelers;
        }

        private void ShowAllPionnen(List<Pion> mogelijkePionnen)
        {
            _logger.LogInformationMessage($"TOON ALLE MOGELIJKE PIONNEN");
            for (int i = 0; i < mogelijkePionnen.Count; i++)
            {
                _logger.LogInformationMessage($"pion id: {mogelijkePionnen[i].Id} kleur: {mogelijkePionnen[i].Kleur} PionType: {mogelijkePionnen[i].PionType}");
            }
        }
    }
}
