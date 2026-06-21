using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models;
using ServerMineAger.Models.Joueurs;

namespace ServerMineAger.Commands
{
    public class CommandeOp : ICommandeServeur
    {
        private readonly ServeurMinecraft _serveur;
        private readonly string _pseudo;
        private bool _etatPrecedent;

        public string Nom => "op player";

        public CommandeOp(ServeurMinecraft serveur, string pseudo)
        {
            _serveur = serveur;
            _pseudo = pseudo;
        }

        public void Executer()
        {
            Joueur? joueur = _serveur.RechercherJoueur(_pseudo);
            if (joueur == null)
            {
                Console.WriteLine($"Could not op {_pseudo}.");
                return;
            }
            _etatPrecedent = joueur.EstOperateur;
            _serveur.DonnerOperator(_pseudo);
        }

        public void Annuler()
        {
            if(!_etatPrecedent)
            {
                _serveur.RetirerOperator(_pseudo);
            }
            else
            {
                Console.WriteLine($"{_pseudo} was already an operator before this command.");
            }
        }
    }
}
