using GanzenBoardGame.Application.Factory;
using GanzenBoardGame.Application.Modals;
using GanzenBoardGame.Application.Modals.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanzenBoardGame.Application.Services
{
    public class GameBoardService : IGameBoardService
    {
        private readonly LocationFactory _locationFactory;

        public GameBoardService(LocationFactory locationFactory)
        {
            _locationFactory = locationFactory;
        }

        public GanzenBoard GeneratePlayerBoard(int lengte)
        {
            GanzenBoard ganzenBoard = new GanzenBoard();
            ganzenBoard.Spelboardvakjes = GenerateLocations(lengte);

            var vakkenMetGans = new int[] { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };
            ganzenBoard.Spelboardvakjes = GenerateGoons(ganzenBoard.Spelboardvakjes, vakkenMetGans);

            return ganzenBoard;
        }

        private List<Location> GenerateGoons(List<Location> locations, int[] isVakMetGooze)
        {
            foreach (var item in isVakMetGooze)
            {
                locations.Where(x => x.SpelersVak == item).First(x => x.IsSpaceWithGoose = true);
            }
            return locations;
        }

        private List<Location> GenerateLocations(int lengte)
        {

            List<Location> locations = new List<Location>();

            for (int i = 1; i <= lengte; i++)
            {
                string locationTypeString;
                switch (i)
                {
                    case BridgeLocatie.BridgeLocation:
                        locationTypeString = "BridgeLocatie";
                        break;
                    case InnLocatie.InnLocation:
                        locationTypeString = "InnLocatie";
                        break;
                    case WellLocatie.WellLocation:
                        locationTypeString = "WellLocatie";
                        break;
                    case MazeLocatie.MazeLocation:
                        locationTypeString = "MazeLocatie";
                        break;
                    case PrisonLocatie.PrisonLocation:
                        locationTypeString = "PrisonLocatie";
                        break;
                    case DeathLocatie.DeathLocation:
                        locationTypeString = "DeathLocatie";
                        break;
                    case EndLocatie.EndLocation:
                        locationTypeString = "EndLocatie";
                        break;
                    default:
                        locationTypeString = "CasualLocatie";
                        break;
                }

                Location locationType = _locationFactory.Create(locationTypeString, i);
                locations.Add(locationType);
            }
            return locations;
        }
    }
}
