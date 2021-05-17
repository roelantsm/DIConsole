using GanzenBoardGame.Application.Logging;

namespace GanzenBoardGame.Application.Modals.Locations
{
    public abstract class Location
    {
        public int SpelersVak { get; set; }
        public bool IsSpaceWithGoose { get; set; } = false;

        public abstract Player OpDezeSoortLocatieAangekomen(Player speler, GanzenBoard ganzenBoard);

        public Location()
        {
        }
    }
}