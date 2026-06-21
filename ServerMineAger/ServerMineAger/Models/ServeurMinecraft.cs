using System;
using System.Collections.Generic;
using System.Text;
using ServerMineAger.Models.Enums;
using ServerMineAger.Models.Joueurs;

namespace ServerMineAger.Models;

public class ServeurMinecraft
{
    private readonly List<Joueur> _joueurs;

    public string AdresseIP { get; private set; }
    public MondeMinecraft Monde { get; private set; }

    public ServeurMinecraft(string adresseIP)
    {
        AdresseIP = adresseIP;
        Monde = new MondeMinecraft("Overworld");
        _joueurs = new List<Joueur>();
    }

    public void AjouterJoueur(Joueur joueur)
    {
        if ( RechercherJoueur(joueur.Pseudo) != null)
        {
            Console.WriteLine($"the player {joueur.Pseudo} is already connected.");
        }
        else
        {
            _joueurs.Add(joueur);
            Console.WriteLine($"the player {joueur.Pseudo} has joined the server.");
        }
    }

    public void KickJoueur(string pseudo)
    {
        Joueur? joueur = RechercherJoueur(pseudo);

        if (joueur == null)
        {
            Console.WriteLine($"Could not kick {pseudo}.");
            return;
        }

        _joueurs.Remove(joueur);
        joueur.Deconnecter();

        Console.WriteLine(joueur.Pseudo + " has been kicked from the server.\n");
    }

    public void RetirerJoueur(string pseudo)
    {
        Joueur? joueur = RechercherJoueur(pseudo);

        if (joueur == null)
        {
            Console.WriteLine($"Could not remove {pseudo}.");
            return;
        }

        _joueurs.Remove(joueur);
        joueur.Deconnecter();
        Console.WriteLine(pseudo + " has left the server.");
    }

    public Joueur? RechercherJoueur(string pseudo)
    {
        foreach (Joueur joueur in _joueurs)
        {
            if (joueur.Pseudo.Equals(pseudo, StringComparison.OrdinalIgnoreCase))
            {
                return joueur;
            }
        }
        return null;
    }

    public void AfficherJoueurs()
    {
        if (_joueurs.Count == 0)
        {
            Console.WriteLine("No player connected.");
            return;
        }
        Console.WriteLine($"Player list :");

        foreach (Joueur joueur in _joueurs)
        {
            Console.WriteLine($"- {joueur.Pseudo} | Role: {joueur.ObtenirRole()} | GameMode: {joueur.GameModeActuel} | Operator: {joueur.EstOperateur}");
        }
    }

    public void DonnerOperator(string pseudo)
    {
        Joueur? joueur = RechercherJoueur(pseudo);
        if (joueur != null)
        {
            joueur.OpJoueur();
            Console.WriteLine("/op " + joueur.Pseudo);
            Console.WriteLine("Oped " + joueur.Pseudo + "");
        }
        else
        {
            Console.WriteLine($"Could not op {pseudo}.");
        }
    }

    public void RetirerOperator(string pseudo)
    {
        Joueur? joueur = RechercherJoueur(pseudo);
        if (joueur != null)
        {
            joueur.DeopJoueur();
            Console.WriteLine("/deop " + joueur.Pseudo);
            Console.WriteLine("De-oped " + joueur.Pseudo + "");
        }
        else
        {
            Console.WriteLine($"Could not de-op {pseudo}.");
        }
    }

    public void ChangerGameMode(string pseudo, GameMode nouveauGameMode)
        {
            Joueur? joueur = RechercherJoueur(pseudo);
            if (joueur != null)
            {
                joueur.ChangerGameMode(nouveauGameMode);
            }
            else
            {
                Console.WriteLine($"Could not change {pseudo} 's game mode.");
            }
    }

    public void ChangerTemps(TempsMonde nouveauTemps)
    {
        Monde.SetTime(nouveauTemps);
    }

    public void ChangerWeather(WeatherType nouveauWeather)
    {
        Monde.SetWeather(nouveauWeather);
    }
}
