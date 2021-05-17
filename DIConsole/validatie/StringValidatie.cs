using GanzenBoardGame.Application.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanzenBoardGame.Application.validatie
{
    public class StringValidatie : IStringValidatie
    {
        public bool BevatGeenCijfers(string userNameInput)
        {
            return !(userNameInput.Any(char.IsDigit));
        }

        public bool BevatJuistAantalCharacters(string userNameInput, int maxLength = 20, int minimumLength = 1)
        {
            return userNameInput.Length <= maxLength && userNameInput.Length >= minimumLength;
        }

        public bool SpelersKiestEenGeldigePion(string gekozenPion, List<Pion> list)
        {
            int.TryParse(gekozenPion, out int parsedInt);
            return list.SingleOrDefault(x => x.Id == parsedInt) != null;
        }


    }
}
