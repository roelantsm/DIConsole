using GanzenBoardGame.Application.Logging;
using GanzenBoardGame.Application.Modals.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Factory
{
    public class LocationFactory
    {

        public LocationFactory()
        {
        }

        public Location Create(string type, int spelersVak)
        {
            try
            {
                Location loc = (Location)Activator.CreateInstance(Type.GetType($"GanzenBoardGame.Application.Modals.Locations.{type}"), new Object[] { spelersVak });
                return loc;
            }
            catch (Exception e)
            {
                return new NullLocation(spelersVak);
            }
        }
    }
}
