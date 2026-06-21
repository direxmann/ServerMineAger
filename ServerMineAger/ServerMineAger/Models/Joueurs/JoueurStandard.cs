using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMineAger.Models.Joueurs
{
    public class JoueurStandard : Joueur
    {
        public JoueurStandard(string pseudo) : base(pseudo) { }

        public override string ObtenirRole()
        {
            return "Player";
        }
    }
}
