using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMineAger.Models.Joueurs
{
    public class Administrateur : Joueur
    {
        public Administrateur(string pseudo) : base(pseudo)
        {
            OpJoueur();
        }
        public override string ObtenirRole()
        {
            return "Admin";
        }
    }
}
