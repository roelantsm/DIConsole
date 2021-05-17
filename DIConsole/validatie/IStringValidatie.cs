using GanzenBoardGame.Application.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace GanzenBoardGame.Application.validatie
{
    public interface IStringValidatie
    {
        bool BevatGeenCijfers(string userNameInput);
        bool SpelersKiestEenGeldigePion(string gekozenPion, List<Pion> list);
        bool BevatJuistAantalCharacters(string userNameInput, int maxLength = 20, int minimumLength = 1);
    }
}
