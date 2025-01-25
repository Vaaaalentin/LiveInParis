using System.Runtime.CompilerServices;

namespace LiveInParis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graphe graphe = RecupererValeurs();


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
                        string[] elem = line.Split(" ");
                        if(elem.Length == 2)
                        {
                            graphe.AjouterNoeud(int.Parse(elem[0]));
                            graphe.AjouterNoeud(int.Parse(elem[1]));
                            graphe.AjouterLien(int.Parse(elem[0]), int.Parse(elem[1]));
                        }
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sReader != null) { sReader.Close(); }
            }
            return graphe; 
        }
    }
}
