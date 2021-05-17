using GanzenBoardGame.Application.Modals.Locations;
using GanzenBoardGame.Application.Modals.Rondes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.Factory
{
    public class RondeFactory
    {
        public RondeFactory()
        {
        }

        public Ronde Create(string type, int currentRonde)
        {
            try
            {
                Ronde loc = (Ronde)Activator.CreateInstance(Type.GetType($"GanzenBoardGame.Application.Modals.Rondes.{type}"), new Object[] { currentRonde });
                return loc;
            }
            catch (Exception e)
            {
                return new NullRonde();
            }
        }
    }
}
