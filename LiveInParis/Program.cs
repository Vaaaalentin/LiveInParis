using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace LiveInParis
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            Graphe graphe = RecupererValeurs();
            string fichierImage = "graphe_rectangle_vide.png";

            Dessin.DessinerGraphe(graphe, fichierImage);
            Dessin.OuvrirImage(fichierImage);
            ///Matrice d'adjacence
            int[,] matriceAdjacence = graphe.CreerMatriceAdjacence();
            AfficherMatrice(matriceAdjacence);

            ///Liste d'adjacence
            List<int>[] listeAdjacence = graphe.CreerListeAdjacence();
            AfficherListe(listeAdjacence);


            int sommetDepart = -1;                     
            while ( sommetDepart < 0 || sommetDepart > 34)
            {   
                Console.WriteLine("\nChoisissez un sommet de départ pour le parcours en largeur et en profondeur (entre 1 et 34)");
                sommetDepart = int.Parse(Console.ReadLine());                   
            }

            ///Parcours en largeur
            Console.WriteLine("\nParcours en Largeur à partir du sommet " + sommetDepart + " : ");
            graphe.ParcoursLargeur(sommetDepart);

            ///Parcours en profondeur
            Console.WriteLine("\n\nParcours en Profondeur à partir du sommet " + sommetDepart + " : ");
            graphe.ParcoursProfondeur(sommetDepart);

            Console.WriteLine("\n");

            ///Vérification de la présence de cycles
            bool existeCycle = graphe.ContientCycle();
            if (existeCycle) { Console.WriteLine("\nLe graphe contient un ou plusieurs cycles"); }
            else { Console.WriteLine("\nLe graphe ne contient pas de cycle"); }
             
        }

        static Graphe RecupererValeurs()
        {
            StreamReader sReader = null;
            Graphe graphe = new Graphe();
            try
            {
                sReader = new StreamReader("soc-karate.mtx");
                string line; 
                while((line = sReader.ReadLine()) != null)
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

            for(int i = 0; i < mat.GetLength(0); i++)
            {
                string ligne = "";
                for(int j = 0; j < mat.GetLength(1); j++)
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
                foreach(int z in tab[i])
                {
                    Console.Write(" " + z);
                }
                Console.WriteLine("");
            }
        }

        
    }

}
