using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMineAger.Commands
{
    public class GestionnaireCommandes
    {
        private readonly List<ICommandeServeur> _historique;

        public GestionnaireCommandes()
        {
            _historique = new List<ICommandeServeur>();
        }

        public void ExecuterCommande(ICommandeServeur commande)
        {
            commande.Executer();
            _historique.Add(commande);
        }

        public void AnnulerCommande(ICommandeServeur commande)
        {
            commande.Annuler();
            _historique.Add(commande);
        }

        public void AnnulerDerniereCommande()
        {
            if (_historique.Count == 0)
            {
                Console.WriteLine("No commands to undo.");
                return;
            }

            ICommandeServeur derniereCommande = _historique[_historique.Count - 1];
            derniereCommande.Annuler();
            _historique.RemoveAt(_historique.Count - 1);
        }

        public void AfficherHistorique()
        {
            if (_historique.Count == 0)
            {
                Console.WriteLine("No commands in history.");
                return;
            }

            Console.WriteLine("Command History:");
            foreach (ICommandeServeur commande in _historique)
            {
                Console.WriteLine("- " + commande.Nom);
            }
        }
    }
}