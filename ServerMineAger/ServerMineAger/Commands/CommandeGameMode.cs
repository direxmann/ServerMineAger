using ServerMineAger.Models;
using ServerMineAger.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models.Joueurs;

namespace ServerMineAger.Commands
{
    public class CommandeGameMode : ICommandeServeur
    {
        private readonly string _pseudo;
        private readonly ServeurMinecraft _serveur;
        private readonly GameMode _nouveauGM;
        private  GameMode _ancienGM;

        public string Nom => "change gamemode";

        public CommandeGameMode(ServeurMinecraft serveur, string pseudo, GameMode nouveauGM)
        {
            _serveur = serveur;
            _pseudo = pseudo;
            _nouveauGM = nouveauGM;
        }

        public void Executer()
        {
            Joueur? joueur = _serveur.RechercherJoueur(_pseudo);
            if (joueur == null)
            {
                Console.WriteLine($"Could not change {_pseudo}'s gamemode.");
                return;
            }
            _ancienGM = joueur.GameModeActuel;
            _serveur.ChangerGameMode(_pseudo, _nouveauGM);
        }

        public void Annuler()
        {
            _serveur.ChangerGameMode(_pseudo, _ancienGM);
        }
    }
}