using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models.Enums;

namespace ServerMineAger.Models.Joueurs
{
    public abstract class Joueur
    {
        public string Pseudo { get; private set; }
        public bool EstConnecte { get; private set; }
        public bool EstOperateur { get; private set; }
        public GameMode GameModeActuel { get; private set; }

        protected Joueur(string pseudo)
        {
            Pseudo = pseudo;
            EstConnecte = true;
            EstOperateur = false;
            GameModeActuel = GameMode.Survival;
        }

        public void Connecter()
        {
            EstConnecte = true;
            Console.WriteLine(Pseudo + " joined the game");
        }

        public void Deconnecter()
        {
            EstConnecte = false;
            Console.WriteLine(Pseudo + " left the game");
        }

        public void OpJoueur()
        {
            EstOperateur = true;
        }

        public void DeopJoueur()
        {
            EstOperateur = false;
        }

        public void ChangerGameMode(GameMode nouveauGameMode)
        {
            GameModeActuel = nouveauGameMode;
            Console.WriteLine("/gamemode " + nouveauGameMode.ToString().ToLower() + " " + Pseudo);
            Console.WriteLine("Set " + Pseudo + " 's game mode to " + nouveauGameMode.ToString().ToLower() + " mode");
        }

        public abstract string ObtenirRole();
    }
}