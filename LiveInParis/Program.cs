using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace LiveInParis
{
    internal class Program
    {

        static void Main(string[] args)
        {

            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LIVINPARIS;UID=root;PASSWORD=root";
            BDD bdd = new BDD(connexionString);

            while (true)
            {
                Console.WriteLine("Menu principal :");
                Console.WriteLine("1. Module Client");
                Console.WriteLine("2. Module Cuisinier");
                Console.WriteLine("3. Module Commande");
                Console.WriteLine("4. Module Statistiques");
                Console.WriteLine("5. Quitter");
                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.Clear();
                        ModuleClient(bdd);
                        break;
                    case "2":
                        Console.Clear();
                        ModuleCuisinier(bdd);
                        break;
                    case "3":
                        Console.Clear();
                        ModuleCommande(bdd);
                        break;
                    case "4":
                        Console.Clear();
                        ModuleStatistiques(bdd);
                        break;
                    case "5":
                        Console.Clear();
                        bdd.Deconnexion();
                        return;
                    default:
                        Console.WriteLine("\nOption invalide. Veuillez réessayer.");
                        break;
                }
            }
        }

        static void ModuleClient(BDD bdd)
        {
            while (true)
            {
                Console.WriteLine("Module Client :");
                Console.WriteLine("1. Ajouter un client");
                Console.WriteLine("2. Supprimer un client");
                Console.WriteLine("3. Modifier un client");
                Console.WriteLine("4. Afficher les clients par ordre alphabétique");
                Console.WriteLine("5. Afficher les clients par rue");
                Console.WriteLine("6. Afficher les clients par montant des achats");
                Console.WriteLine("7. Retour au menu principal");
                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine();
                        bdd.AjouterClient();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        bdd.SupprimerClient();
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        bdd.ModifierClient();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        bdd.AfficherClientAsc();
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.Clear();
                        bdd.AfficherClientRue();
                        break;
                    case "6":
                        Console.WriteLine();
                        bdd.AfficherClientAchat();
                        Console.WriteLine();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        Console.WriteLine();
                        break;

                }
            }
        }

        static void ModuleCuisinier(BDD bdd)
        {
            while (true)
            {
                Console.WriteLine("Module Cuisinier :");
                Console.WriteLine("1. Ajouter un cuisinier");
                Console.WriteLine("2. Supprimer un cuisinier");
                Console.WriteLine("3. Modifier un cuisinier");
                Console.WriteLine("4. Afficher les cuisiniers par ordre alphabétique");
                Console.WriteLine("5. Afficher les clients servis par un cuisinier");
                Console.WriteLine("6. Afficher les plats réalisés par fréquence");
                Console.WriteLine("7. Afficher le plat du jour");
                Console.WriteLine("8. Retour au menu principal");
                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine();
                        bdd.AjouterCuisinier();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        bdd.SupprimerCuisinier();
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        bdd.ModifierCuisinier();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        bdd.AfficherCusinierAsc();
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine();
                        bdd.ClientsServis();
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine();
                        bdd.PlatsFrequences();
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.WriteLine();
                        bdd.AfficherPlatDuJour();
                        Console.WriteLine();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void ModuleCommande(BDD bdd)
        {
            while (true)
            {
                Console.WriteLine("Module Commande :");
                Console.WriteLine("1. Calculer le prix d'une commande");
                Console.WriteLine("2. Retour au menu principal");
                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine();
                        bdd.CalculerPrixCommande();
                        Console.WriteLine();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void ModuleStatistiques(BDD bdd)
        {
            while (true)
            {
                Console.WriteLine("Module Statistiques :");
                Console.WriteLine("1. Afficher par cuisinier le nombre de livraisons effectuées");
                Console.WriteLine("2. Afficher les commandes selon une période de temps");
                Console.WriteLine("3. Afficher la moyenne des prix des commandes");
                Console.WriteLine("4. Afficher la moyenne des comptes clients");
                Console.WriteLine("5. Afficher la liste des commandes pour un client selon la nationalité des plats");
                Console.WriteLine("6. Retour au menu principal");
                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine();
                        bdd.AfficherCommandesCuisinier();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.Write("Date de début (YYYY-MM-DD) : ");
                        DateTime datedebut = DateTime.Parse(Console.ReadLine());
                        Console.Write("Date de fin (YYYY-MM-DD) : ");
                        DateTime datefin = DateTime.Parse(Console.ReadLine());
                        bdd.AfficherCommandesTemps(datedebut, datefin);
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        bdd.AfficherMoyennePrixCommandes();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        bdd.AfficherMoyenneCompteClients();
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine();
                        bdd.ListeCommandeClients();
                        Console.WriteLine();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        Console.WriteLine();
                        break;
                }
            }
            
            //Graphe graphe = RecupererValeurs();
            //string fichierImage = "graphe_rectangle_vide.png";

            //Dessin.DessinerGraphe(graphe, fichierImage);
            //Dessin.OuvrirImage(fichierImage);
            /////Matrice d'adjacence
            //int[,] matriceAdjacence = graphe.CreerMatriceAdjacence();
            //AfficherMatrice(matriceAdjacence);

            /////Liste d'adjacence
            //List<int>[] listeAdjacence = graphe.CreerListeAdjacence();
            //AfficherListe(listeAdjacence);


            //int sommetDepart = -1;                     
            //while ( sommetDepart < 0 || sommetDepart > 34)
            //{   
            //    Console.WriteLine("\nChoisissez un sommet de départ pour le parcours en largeur et en profondeur (entre 1 et 34)");
            //    sommetDepart = int.Parse(Console.ReadLine());                   
            //}

            /////Parcours en largeur
            //Console.WriteLine("\nParcours en Largeur à partir du sommet " + sommetDepart + " : ");
            //graphe.ParcoursLargeur(sommetDepart);

            /////Parcours en profondeur
            //Console.WriteLine("\n\nParcours en Profondeur à partir du sommet " + sommetDepart + " : ");
            //graphe.ParcoursProfondeur(sommetDepart);

            //Console.WriteLine("\n");

            /////Vérification de la présence de cycles
            //bool existeCycle = graphe.ContientCycle();
            //if (existeCycle) { Console.WriteLine("\nLe graphe contient un ou plusieurs cycles"); }
            //else { Console.WriteLine("\nLe graphe ne contient pas de cycle"); }

        }

        /// <summary>
        /// Fonction classique permettant d'extraire les données du fichier soc-karate.mtx 
        /// On créé ensuite le graphe à partir des données lues
        /// </summary>
        /// <returns>Un graphe qui contient les données du fichier en question</returns>
        public static Graphe RecupererValeurs()
        {
            StreamReader sReader = null;
            Graphe graphe = new Graphe();
            try
            {
                sReader = new StreamReader("soc-karate.mtx");
                string line;
                while ((line = sReader.ReadLine()) != null)
                {
                    if (line[0] != '%')
                    {
                        string[] elem = line.Split(' ');

                        if (elem.Length == 2)
                        {
                            int n1 = int.Parse(elem[0]);
                            int n2 = int.Parse(elem[1]);

                            graphe.AjouterNoeud(n1);
                            graphe.AjouterNoeud(n2);
                            graphe.AjouterLien(n1, n2);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + " Yo ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Yo2 ");
            }
            finally
            {
                if (sReader != null) { sReader.Close(); }
            }
            return graphe;
        }

        static void AfficherMatrice(int[,] mat)
        {
            Console.WriteLine("Voici la matrice d'adjacence : \n");

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                string ligne = "";
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    ligne += mat[i, j] + " ";
                }
                Console.WriteLine(ligne);
            }
            Console.WriteLine("");
        }

        static void AfficherListe(List<int>[] tab)
        {
            Console.WriteLine("Voici la liste d'adjacence : \n");

            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(i + 1 + ":");
                foreach (int z in tab[i])
                {
                    Console.Write(" " + z);
                }
                Console.WriteLine("");
            }
        }
        static int Actions(int rep)
        {
            Console.WriteLine("BONJOUR ! `\nSouhaitez-vous accéder à l'espace Client ? (y/n)");
            string client = Console.ReadLine();
            if (client == "y")
            {
                do
                {
                    Console.WriteLine("(1) Recruter un nouvel employé en cuisine. ");
                    Console.WriteLine("(2) Recruter un nouvel employé en salle.");
                    Console.WriteLine("(3) Licencier un employé.");
                    Console.WriteLine("(4) Afficher informations restaurant. ");
                    Console.WriteLine("(5) Acheter couverts supplémentaires. ");
                    Console.WriteLine("(6) Voir informations recettes de la semaine.");
                    Console.WriteLine("(7) Total factures à payer.");
                    Console.WriteLine("(8) Passer à la semaine suivante.");
                    rep = int.Parse(Console.ReadLine());
                } while (rep < 1 || rep > 8);
            }
            return rep;
        }
    }

}
