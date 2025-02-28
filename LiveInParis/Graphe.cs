using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{
    public class Graphe
    {
        public List<Noeud> Noeuds { get; set; }
        public List<Lien> Liens { get; set; }

        public Graphe()
        {       
            Noeuds = new List<Noeud>();
            Liens = new List<Lien>();
        }

        public void AjouterNoeud(int Id)
        {

            bool estExist = true;

            foreach (Noeud nod in Noeuds)
            {
                if (nod.Id == Id) { estExist = false; break; }
            }
            if (estExist)
            {
                Noeuds.Add(new Noeud(Id));
            }
        }

        public void AjouterLien(int n1, int n2)
        {
            Noeud noeud1 = null;
            Noeud noeud2 = null;

            foreach (Noeud n in Noeuds)
            {
                if (n.Id == n1)
                {
                    noeud1 = n;
                }
                if (n.Id == n2)
                {
                    noeud2 = n;
                }
            }

            if (noeud1 != null && noeud2 != null)
            {
                bool lienExist = true;

                foreach (Lien l in Liens)
                {
                    if ((l.Noeud1 == noeud1 && l.Noeud2 == noeud2) || (l.Noeud1 == noeud2 && l.Noeud2 == noeud2))
                    {
                        lienExist = false;
                        break;
                    }
                }
                if (lienExist)
                {
                    Liens.Add(new Lien(noeud1, noeud2));
                }
            }
        }

        public int[,] CreerMatriceAdjacence()
        {
            int[,] mat = new int[Noeuds.Count, Noeuds.Count];
            foreach (Lien l in Liens)
            {
                mat[l.Noeud1.Id-1, l.Noeud2.Id-1] = 1;
                mat[l.Noeud2.Id-1, l.Noeud1.Id-1] = 1;
            }
            return mat;
        }
        
        public List<int>[] CreerListeAdjacence()
        {
            List<int>[] tab = new List<int>[Noeuds.Count];

            for (int i = 0; i < Noeuds.Count; i++)
            {
                tab[i] = new List<int>();
            }

            foreach (Lien l in Liens)
            {
                tab[l.Noeud2.Id - 1].Add(l.Noeud1.Id);
                tab[l.Noeud1.Id - 1].Add(l.Noeud2.Id);
            }
            return tab;
        }

        public void ParcoursLargeur(int depart)
        {
            List<int> visite = new List<int>();
            List<int>[] parcours = CreerListeAdjacence();

            Queue<int> file = new Queue<int>();

            file.Enqueue(depart);
            visite.Add(depart);

            int compteSommet = 1;
            while (file.Count > 0) 
            {
                int noeud = file.Dequeue();
                Console.Write(noeud + " ");

                foreach(int n in parcours[noeud - 1])
                {
                    if (!visite.Contains(n))
                    {
                        compteSommet++;
                        file.Enqueue(n);
                        visite.Add(n);
                    }
                }
            }
            Console.WriteLine("\nLe parcours en largeur a visité "+ compteSommet + " sommets !");
        }

        public void ParcoursProfondeur(int depart)
        {
            List<int> visite = new List<int>();
            Stack<int> pile = new Stack<int>();

            List<int>[] parcours = CreerListeAdjacence();

            pile.Push(depart);

            while (pile.Count > 0) 
            { 
                int noeud = pile.Pop();
                if (!visite.Contains(noeud))
                {
                    visite.Add(noeud);
                    Console.Write(noeud + " ");

                    foreach(int n in parcours[noeud - 1])
                    {
                        if (!visite.Contains(n))
                        {
                            pile.Push(n);
                        }
                    }
                }

            }
        }

    }
}
