using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models;
using ServerMineAger.Models.Joueurs;

namespace ServerMineAger.Commands
{
    public class CommandeAddPlayer : ICommandeServeur
    {
        private readonly ServeurMinecraft _serveur;
        private readonly Joueur _joueur;

        public string Nom => "Add player " + _joueur.Pseudo;

        public CommandeAddPlayer(ServeurMinecraft serveur, Joueur joueur)
        {
            _serveur = serveur;
            _joueur = joueur;
        }

        public void Executer()
        {
            _serveur.AjouterJoueur(_joueur);
        }

        public void Annuler()
        {
            _serveur.RetirerJoueur(_joueur.Pseudo);
        }
    }
}
