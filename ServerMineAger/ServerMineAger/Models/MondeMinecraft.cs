using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models.Enums;

namespace ServerMineAger.Models
{
    public class MondeMinecraft
    {
        public string Nom { get; private set; }
        public TempsMonde TempsActuel { get; private set; }
        public WeatherType WeatherActuel { get; private set; }

        public MondeMinecraft(string nom)
        {
            Nom = nom;
            TempsActuel = TempsMonde.Day;
        }

        public void SetTime(TempsMonde nouveauTemps)
        {
            TempsActuel = nouveauTemps;
            Console.WriteLine("/time set " + nouveauTemps.ToString().ToLower());
            Console.WriteLine($"Set the time to {(int)nouveauTemps}");
        }

        public void SetWeather(WeatherType weather)
        {
            Console.WriteLine("/weather " + weather.ToString().ToLower());
            Console.WriteLine($"Set the weather to {weather}");
        }
    }
}