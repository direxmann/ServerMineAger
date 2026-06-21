using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models;
using ServerMineAger.Models.Enums;

namespace ServerMineAger.Commands
{
    public class CommandeTimeSet : ICommandeServeur
    {
        private readonly ServeurMinecraft _serveur;
        private readonly TempsMonde _nouveauTemps;
        private TempsMonde _tempsPrecedent;
        public string Nom => "time set";

        public CommandeTimeSet(ServeurMinecraft serveur, TempsMonde nouveauTemps)
        {
            _serveur = serveur;
            _nouveauTemps = nouveauTemps;
        }

        public void Executer()
        {
            _tempsPrecedent = _serveur.Monde.TempsActuel;
            _serveur.ChangerTemps(_nouveauTemps);
        }

        public void Annuler()
        {
            _serveur.ChangerTemps(_tempsPrecedent);
        }
    }
}
