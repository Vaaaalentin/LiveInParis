using System.Runtime.CompilerServices;

namespace LiveInParis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Graphe graphe = RecupererValeurs();

            int[,] matriceAdjacence = graphe.CreerMatriceAdjacence();
            AfficherMatrice(matriceAdjacence);

            List<int>[] listeAdjacence = graphe.CreerListeAdjacence();
            AfficherListe(listeAdjacence);
            
            
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
            Console.WriteLine("");
        }

        
    }
}
