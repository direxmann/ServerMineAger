using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMineAger.Models.Joueurs
{
    public class Moderateur : Joueur
    {
        public Moderateur(string pseudo) : base(pseudo)
        {
            OpJoueur();
        }

        public override string ObtenirRole()
        {
            return "Modo";
        }
    }
}
