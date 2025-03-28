using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace LiveInParis
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

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
