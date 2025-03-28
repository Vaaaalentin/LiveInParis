using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace LiveInParis
{
    internal class Program
    {
        static void InterfaceUtilisateur()
        {
            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=LIVINPARIS;UID=root;PASSWORD=root";
            BDD bdd = new BDD(connexionString);

            bdd.AfficherClientAsc();
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

                bdd.SupprimerClient();
                bdd.AfficherClientAsc();
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
        }
        static void Main(string[] args)
        {
            InterfaceUtilisateur();

            ///On peut mettre un graphe de station en mettant une variable /!\
            Graphe<Station> graphe = RecupererValeurs();
            Console.WriteLine("Nombre de stations enregistrées : "+ graphe.Noeuds.Count);
            Console.WriteLine("Nombre de liens enregistrés : " + graphe.Liens.Count);
            Console.WriteLine("");
            foreach (Noeud < Station > n in graphe.Noeuds) { 
                if(n.type.libStation == "Charles de Gaulle - Etoile") { n.type.InfoStation(); }
            }
            Console.WriteLine("");
            for (int i = 30; i < 60; i++)
            {
                graphe.Liens[i].InfoLien();
            }


            //string fichierImage = "graphe_rectangle_vide.png";
            //Dessin.DessinerGraphe(graphe, fichierImage);
            //Dessin.OuvrirImage(fichierImage);

            ///Matrice d'adjacence
            //int[,] matriceAdjacence = graphe.CreerMatriceAdjacence();
            //AfficherMatrice(matriceAdjacence);

            /////Liste d'adjacence
            //List<int>[] listeAdjacence = graphe.CreerListeAdjacence();
            //AfficherListe(listeAdjacence);


            int sommetDepart = -1;
            bool estEntier = true;
            while ( sommetDepart < 0 || sommetDepart > 34 || estEntier == false)
            {   
                Console.WriteLine("\nChoisissez un sommet de départ pour le parcours en largeur et en profondeur (entre 1 et 34)");
                string input = Console.ReadLine();
                estEntier = int.TryParse(input, out sommetDepart);

            }

            ///Parcours en largeur
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

        static Graphe<Station> RecupererValeurs()
        {
            Graphe<Station> graphe = new Graphe<Station>();
            StreamReader sReader = null;

            try
            {
                sReader = new StreamReader("MetroParis(Noeuds).csv");
                string line;
                while ((line = sReader.ReadLine()) != null)
                {
                    if (line[0] != 'I')
                    {
                        string[] elem = line.Split(';');
                        elem[1] = (elem[1] == "3bis") ? "31" : elem[1];
                        elem[1] = (elem[1] == "7bis") ? "71" : elem[1];
                        string number = elem[3].Replace('.', ',');
                        string number2 = elem[4].Replace('.', ',');

                        Station station = new Station(int.Parse(elem[0]), int.Parse(elem[1]), elem[2],
                            double.Parse(number), double.Parse(number2), elem[5], int.Parse(elem[6]));

                        graphe.AjouterNoeud(station.IdStation, station);
                        
                    }
                }
                Console.WriteLine("Extraction terminée des stations.");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + " Erreur 1 ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Erreur 2 ");
            }
            finally
            {
                if (sReader != null) { sReader.Close(); }
            }

            try
            {
                sReader = new StreamReader("MetroParis(Arcs).csv");
                string line;
 
                while ((line = sReader.ReadLine()) != null)
                {
                    if (line[0] != 'S')
                    {

                        string[] elem = line.Split(';');

                        if (elem[2]!= "") //Eviter les erreurs avec les départ de ligne
                        {
                            ///Stationfin la station d'arrivee
                            Noeud<Station> stationfin = graphe.Noeuds.FirstOrDefault(n => n.Id == int.Parse(elem[2]));
                            ///Stationdep la station de départ
                            Noeud<Station> stationdep = graphe.Noeuds.FirstOrDefault(n => n.Id == int.Parse(elem[0]));

                            graphe.AjouterLien(stationdep, stationfin, int.Parse(elem[4]), false);
                        }
                        if (elem[3] != "") //Eviter les erreurs avec les terminus
                        {
                            Noeud<Station> stationdep = graphe.Noeuds.FirstOrDefault(n => n.Id == int.Parse(elem[0]));
                            ///Stationdep la station de départ
                            Noeud<Station> stationfin = graphe.Noeuds.FirstOrDefault(n => n.Id == int.Parse(elem[3]));

                            graphe.AjouterLien(stationdep, stationfin, int.Parse(elem[4]), false);
                        }
                        if (elem[5] != "")
                        {
                            Noeud<Station> stationdep = graphe.Noeuds.FirstOrDefault(n => n.Id == int.Parse(elem[0]));
                            List<Noeud<Station>> Corresp = new List<Noeud<Station>>();
                            foreach(Noeud<Station> noeud in graphe.Noeuds)
                            {
                                if(noeud.type.libStation == elem[1] && noeud.type.IdStation != int.Parse(elem[0]))
                                {
                                    Corresp.Add(noeud);
                                }
                            }
                            foreach (Noeud<Station> station in Corresp) {
                                graphe.AjouterLien(stationdep, station, int.Parse(elem[5]), true);
                            }

                        }
                    }
                }
                Console.WriteLine("Extraction terminée des liens.");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + " Erreur 1 ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Erreur 2 ");
            }
            finally
            {
                if (sReader != null) { sReader.Close(); }
            }

            return graphe;

        }


        //static void AfficherMatrice(int[,] mat)
        //{
        //    Console.WriteLine("Voici la matrice d'adjacence : \n");

        //    for(int i = 0; i < mat.GetLength(0); i++)
        //    {
        //        string ligne = "";
        //        for(int j = 0; j < mat.GetLength(1); j++)
        //        {
        //            ligne += mat[i, j] + " ";
        //        }
        //        Console.WriteLine(ligne);
        //    }
        //    Console.WriteLine("");
        //}
        
        //static void AfficherListe(List<int>[] tab)
        //{
        //    Console.WriteLine("Voici la liste d'adjacence : \n");

        //    for (int i = 0; i < tab.Length; i++)
        //    {
        //        Console.Write(i + 1 + ":");
        //        foreach(int z in tab[i])
        //        {
        //            Console.Write(" " + z);
        //        }
        //        Console.WriteLine("");
        //    }
        //}

        
    }

}
