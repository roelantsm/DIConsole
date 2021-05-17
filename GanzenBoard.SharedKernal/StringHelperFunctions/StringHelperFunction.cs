using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GanzenBoardGame.SharedKernal.StringHelperFunctions
{
    public static class StringHelperFunction
    {
        public static string GeefEenNieuweLijn(this string input)
        {
            return new string('-', 20);
        }

        public static string LijnAlleSpelers(this string input, int aantalSpelers)
        {
            string s = String.Empty;
            for (int i = 0; i < aantalSpelers; i++)
            {
                s += String.Format("PIECE {0} \t", i + 1);
            }
            return s;
        }

        public static string ShowCurrentTurn(this string input, int currentTurn)
        {
            return $"Turn {currentTurn}";
        }

        //public static string ShowWhatThePlayerThrowedAndPosition(this string input, (int worp1, int worp2) worpen, int vorigeTile = 0)
        //{
        //    if (vorigeTile == 0)
        //    {
        //        return $"{worpen.worp1} + {worpen.worp2}: S{worpen.worp1 + worpen.worp2}";
        //    }
        //    return $"{worpen.worp1} + {worpen.worp2}: S{worpen.worp1 + worpen.worp2}";
        //}
    }
}
