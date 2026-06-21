using ServerMineAger.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models.Enums;

namespace ServerMineAger.Commands
{
    public class CommandeWeather : ICommandeServeur
    {
        private readonly ServeurMinecraft _serveur;
        private readonly WeatherType _nouveauWeather;
        private WeatherType _ancienWeather;

        public string Nom => "weather";

        public CommandeWeather(ServeurMinecraft serveur, WeatherType nouveauWeather)
        {
            _serveur = serveur;
            _nouveauWeather = nouveauWeather;
        }

        public void Executer()
        {
            _ancienWeather = _serveur.Monde.WeatherActuel;
            _serveur.ChangerWeather(_nouveauWeather);
        }

        public void Annuler()
        {
            _serveur.ChangerWeather(_ancienWeather);
        }
    }
}
