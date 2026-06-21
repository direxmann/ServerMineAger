using ServerMineAger.Commands;
using ServerMineAger.Models;
using ServerMineAger.UI;

namespace ServerMineAger
{
    public class Program
    {
        public static void Main()
        {
            ServeurMinecraft serveur = new ServeurMinecraft("127.0.0.1");
            GestionnaireCommandes gestionnaireCommandes = new GestionnaireCommandes();

            MenuPrincipal menu = new MenuPrincipal(serveur, gestionnaireCommandes);
            menu.Lancer();
        }
    }
}