using GanzenBoardGame.Application.Logging;
using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.UserInput;
using GanzenBoardGame.Application.validatie;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ILogger _logger;
        private readonly IConsoleInput _consoleInput;
        private readonly INumbervalidator _numberValidator;
        private readonly IStringValidatie _stringValidatie;
        private readonly IDateTimeValidatie _dateTimeValidatie;

        public PlayerService(
            GanzenBoardGame.Application.Logging.ILogger logger,
            IConsoleInput consoleInput,
            INumbervalidator numberValidator,
            IStringValidatie stringValidatie,
            IDateTimeValidatie dateTimeValidatie)
        {
            _logger = logger;
            _consoleInput = consoleInput;
            _numberValidator = numberValidator;
            _stringValidatie = stringValidatie;
            _dateTimeValidatie = dateTimeValidatie;
        }

        public List<Player> SetupNewSpelers()
        {
            int aantalSpelers = KiesHetAantalSpelers();
            _logger.LogInformationMessage($"gekozen spelersAantal: {aantalSpelers}");
            List<Player> splelers = GetPersoonlijkeInformatieSpelers(aantalSpelers);
            return splelers;
        }

        public int KiesHetAantalSpelers()
        {
            while (true)
            {
                _logger.LogInformationMessage($"Was is het spelersAantal? Kies een getal tussen {1} en {4}");
                var spelersAantal = _consoleInput.ReadUserInput();
                var isGelukt = _numberValidator.SpelersAantalValidate(spelersAantal, Player.maxAantalPlayers, 1);
                if (isGelukt)
                {
                    return int.Parse(spelersAantal);
                }
                else
                {
                    _logger.LogInformationMessage($"{spelersAantal} is geen geldig spelersAantal");
                }
            }
        }


        private String SpelerKiestUsername(int indexSpeler)
        {
            String gekozenPlayerName = string.Empty;

            bool SpelerHeeftEenGeldigeNaamGekozen = false;
            _logger.LogInformationMessage($"Wat is de naam van speler {indexSpeler}");

            while (!SpelerHeeftEenGeldigeNaamGekozen)
            {
                gekozenPlayerName = _consoleInput.ReadUserInput();

                var isGeenNummersGelukt = _stringValidatie.BevatGeenCijfers(gekozenPlayerName);
                var isJuisteLengteGelukt = _stringValidatie.BevatJuistAantalCharacters(gekozenPlayerName);

                if (isGeenNummersGelukt && isJuisteLengteGelukt)
                {
                    _logger.LogInformationMessage($"speler {indexSpeler} heeft als Username {gekozenPlayerName}");
                    SpelerHeeftEenGeldigeNaamGekozen = true;
                }
                else
                {
                    _logger.LogErrorMessage($"speler {indexSpeler} heeft geen geldige username gekozen");
                    _logger.LogInformationMessage($"Wat is de naam van speler {indexSpeler}");
                }
            }
            return gekozenPlayerName;
        }


        private DateTime SpelerKiestEenGeboorteDatum(int indexSpeler)
        {
            DateTime gekozenDateTimeParsed = DateTime.Now;

            bool SpelerHeeftEenGeldigeGeboorteDatumGekozen = false;
            _logger.LogInformationMessage($"Wat is de geboorteDatum van speler {indexSpeler}");
            _logger.LogInformationMessage($"het correcte format is (e.g. 10/22/1987)");

            // kies een geboorteDatum
            while (!SpelerHeeftEenGeldigeGeboorteDatumGekozen)
            {
                var gekozenDatetimeInput = _consoleInput.ReadUserInput();
                // patroon & klasse van maken
                gekozenDateTimeParsed = _dateTimeValidatie.ParseStringToDatetime(gekozenDatetimeInput);

                if (gekozenDateTimeParsed != default && gekozenDateTimeParsed != DateTime.MinValue && gekozenDateTimeParsed.Year != DateTime.Now.Year)
                {
                    _logger.LogInformationMessage($"speler {indexSpeler} heeft als geboorteDatum {gekozenDatetimeInput}");
                    SpelerHeeftEenGeldigeGeboorteDatumGekozen = true;
                }
                else
                {
                    _logger.LogErrorMessage($"speler {indexSpeler} heeft geen geldige geboorteDatum gekozen");
                    _logger.LogInformationMessage($"Wat is de geboortedatum van speler {indexSpeler}");
                }
            }
            return gekozenDateTimeParsed;
        }

        private Player CreateSpeler(int indexSpeler)
        {
            string username = SpelerKiestUsername(indexSpeler);
            DateTime dateTime = SpelerKiestEenGeboorteDatum(indexSpeler);

            return new Player { Id = indexSpeler, Name = username, GeboorteDatum = dateTime };
        }


        private List<Player> GetPersoonlijkeInformatieSpelers(int gekozenSpelersAantal)
        {

            List<Player> spelers = new List<Player>();
            for (int i = 1; i <= gekozenSpelersAantal; i++)
            {
                spelers.Add(CreateSpeler(i));
            }

            return spelers;
        }
    }
}
