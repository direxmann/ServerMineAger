using ServerMineAger.Models;
using ServerMineAger.Models.Joueurs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMineAger.Commands
{
    public class CommandeKick : ICommandeServeur
    {
        private readonly ServeurMinecraft _serveur;
        private readonly string _nom;
        private Joueur? _joueur;

        public string Nom => "kick " + _nom;

        public CommandeKick(ServeurMinecraft serveur, string nom)
        {
            _serveur = serveur;
            _nom = nom;
        }

        public void Executer()
        {
            _joueur = _serveur.RechercherJoueur(_nom);
            _serveur.KickJoueur(_nom);
        }

        public void Annuler()
        {
            if (_joueur != null)
            {
                _serveur.AjouterJoueur(_joueur);
            }
        }
    }
}
