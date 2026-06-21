using System;
using ServerMineAger.Commands;
using ServerMineAger.Models;
using ServerMineAger.Models.Enums;
using ServerMineAger.Models.Joueurs;

namespace ServerMineAger.UI
{
    public class MenuPrincipal
    {
        private readonly ServeurMinecraft _serveur;
        private readonly GestionnaireCommandes _gestionnaireCommandes;

        public MenuPrincipal(ServeurMinecraft serveur, GestionnaireCommandes gestionnaireCommandes)
        {
            _serveur = serveur;
            _gestionnaireCommandes = gestionnaireCommandes;
        }

        public void Lancer()
        {
            bool continuer = true;

            while (continuer)
            {
                AfficherMenu();

                Console.Write("Choice: ");
                string? choix = Console.ReadLine();

                Console.WriteLine();

                switch (choix)
                {
                    case "1":
                        AjouterJoueur();
                        break;

                    case "2":
                        _serveur.AfficherJoueurs();
                        break;

                    case "3":
                        OpJoueur();
                        break;

                    case "4":
                        DeopJoueur();
                        break;

                    case "5":
                        ChangerGameMode();
                        break;

                    case "6":
                        ChangerTemps();
                        break;

                    case "7":
                        ChangerWeather();
                        break;

                    case "8":
                        KickJoueur();
                        break;

                    case "9":
                        _gestionnaireCommandes.AnnulerDerniereCommande();
                        break;

                    case "10":
                        _gestionnaireCommandes.AfficherHistorique();
                        break;

                    case "0":
                        continuer = false;
                        Console.WriteLine("Server console closed.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void AfficherMenu()
        {
            Console.WriteLine("===== ServerMineAger Console =====");
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. Show player list");
            Console.WriteLine("3. Op player");
            Console.WriteLine("4. Deop player");
            Console.WriteLine("5. Change gamemode");
            Console.WriteLine("6. Change time");
            Console.WriteLine("7. Change weather");
            Console.WriteLine("8. Undo last command");
            Console.WriteLine("9. Show command history");
            Console.WriteLine("0. Quit");
            Console.WriteLine("==================================");
        }

        private void AjouterJoueur()
        {
            string pseudo = LireTexte("Player name: ");

            Console.WriteLine("Player type:");
            Console.WriteLine("1. Player");
            Console.WriteLine("2. Moderator");
            Console.WriteLine("3. Admin");
            Console.Write("Choice: ");

            string? choix = Console.ReadLine();

            Joueur joueur;

            switch (choix)
            {
                case "2":
                    joueur = new Moderateur(pseudo);
                    break;

                case "3":
                    joueur = new Administrateur(pseudo);
                    break;

                default:
                    joueur = new JoueurStandard(pseudo);
                    break;
            }

            ICommandeServeur commande = new CommandeAddPlayer(_serveur, joueur);
            _gestionnaireCommandes.ExecuterCommande(commande);
        }

        private void OpJoueur()
        {
            string pseudo = LireTexte("Player to op: ");

            ICommandeServeur commande = new CommandeOp(_serveur, pseudo);
            _gestionnaireCommandes.ExecuterCommande(commande);
        }

        private void DeopJoueur()
        {
            string pseudo = LireTexte("Player to deop: ");

            ICommandeServeur commande = new CommandeOp(_serveur, pseudo);
            _gestionnaireCommandes.AnnulerCommande(commande);
        }

        private void ChangerGameMode()
        {
            string pseudo = LireTexte("Player name: ");
            GameMode gameMode = ChoisirGameMode();

            ICommandeServeur commande = new CommandeGameMode(_serveur, pseudo, gameMode);
            _gestionnaireCommandes.ExecuterCommande(commande);
        }

        private void ChangerTemps()
        {
            TempsMonde temps = ChoisirTemps();

            ICommandeServeur commande = new CommandeTimeSet(_serveur, temps);
            _gestionnaireCommandes.ExecuterCommande(commande);
        }

        private void ChangerWeather()
        {
            WeatherType weather = ChoisirWeather();

            ICommandeServeur commande = new CommandeWeather(_serveur, weather);
            _gestionnaireCommandes.ExecuterCommande(commande);
        }

        private string LireTexte(string message)
        {
            string? texte;

            do
            {
                Console.Write(message);
                texte = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(texte));

            return texte;
        }

        private GameMode ChoisirGameMode()
        {
            Console.WriteLine("Gamemode:");
            Console.WriteLine("1. Survival");
            Console.WriteLine("2. Creative");
            Console.WriteLine("3. Adventure");
            Console.WriteLine("4. Spectator");
            Console.Write("Choice: ");

            string? choix = Console.ReadLine();

            switch (choix)
            {
                case "2":
                    return GameMode.Creative;

                case "3":
                    return GameMode.Adventure;

                case "4":
                    return GameMode.Spectator;

                default:
                    return GameMode.Survival;
            }
        }

        private TempsMonde ChoisirTemps()
        {
            Console.WriteLine("Time:");
            Console.WriteLine("1. Day");
            Console.WriteLine("2. Night");
            Console.Write("Choice: ");

            string? choix = Console.ReadLine();

            switch (choix)
            {
                case "2":
                    return TempsMonde.Night;

                default:
                    return TempsMonde.Day;
            }
        }

        private WeatherType ChoisirWeather()
        {
            Console.WriteLine("Weather:");
            Console.WriteLine("1. Clear");
            Console.WriteLine("2. Rain");
            Console.WriteLine("3. Thunder");
            Console.WriteLine("4. Snow");
            Console.Write("Choice: ");

            string? choix = Console.ReadLine();

            switch (choix)
            {
                case "2":
                    return WeatherType.Rain;

                case "3":
                    return WeatherType.Thunder;

                case "4":
                    return WeatherType.Snow;

                default:
                    return WeatherType.Clear;
            }
        }

        private void KickJoueur()
        {
            string pseudo = LireTexte("Player to kick: ");
            ICommandeServeur commande = new CommandeKick(_serveur, pseudo);
            _gestionnaireCommandes.ExecuterCommande(commande);
        }
    }
}