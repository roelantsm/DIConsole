namespace GanzenBoardGame.Models.Locations
{
    public abstract class Location
    {
        public int SpelersVak { get; set; }
        public bool IsSpaceWithGoose { get; set; } = false;
    }
}