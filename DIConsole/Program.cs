using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using GanzenBoardGame.Application.Logging;
using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.UserInput;
using GanzenBoardGame.Application.validatie;
using System.Globalization;
using GanzenBoardGame.Application.Factory;
using GanzenBoardGame.Application.Services;

namespace DIConsole
{
    public class Program
    {
        private readonly ILogger _logger;
        private readonly Game Game;

        public Program(ILogger logger, Game game)
        {
            _logger = logger;
            this.Game = game;
        }

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
            Console.ReadKey(true);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    #region Programn
                    services.AddTransient<Program>();
                    #endregion

                    #region logging
                    services.AddTransient<ILogger, ConsoleLogger>();
                    // services.AddTransient<ILogger, LogLogger>();
                    #endregion

                    #region modals
                    services.AddTransient<Game>();
                    #endregion

                    #region userInput
                    services.AddTransient<IConsoleInput, ConsoleInput>();
                    #endregion

                    #region validatie
                    services.AddTransient<INumbervalidator, Numbervalidator>();
                    services.AddTransient<IStringValidatie, StringValidatie>();
                    services.AddTransient<IDateTimeValidatie, DateTimeValidatie>();
                    #endregion

                    #region factory
                    services.AddTransient<LocationFactory>();
                    services.AddTransient<RondeFactory>();
                    #endregion

                    #region services
                    services.AddTransient<IGameBoardService, GameBoardService>();
                    services.AddTransient<IPlayerService, PlayerService>();
                    services.AddTransient<IPionService, PionService>();
                    services.AddTransient<IRoundService, RoundService>();
                    services.AddTransient<IGameService, GameService>();
                    #endregion

                });
        }

        public void Run()
        {
            _logger.LogInformationMessage("Start a new game");

           Game.SetupNewGame();
           Game.PlayGame();
        }

    }
}
