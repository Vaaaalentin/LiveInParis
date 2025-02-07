using System;
using System.Collections.Generic;
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



    }
}
