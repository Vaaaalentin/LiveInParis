using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{
    public class Graphe
    {
        public List<Noeud> noeuds;
        public List<Lien> liens;

        public Graphe()
        {       
            noeuds = new List<Noeud>();
            liens = new List<Lien>();
        }

        public List<Lien> Liens
        {
            get; set;
        }

        public List<Noeud> Noeuds
        {
            get; set; 
        }

        public void AjouterNoeud(int Id)
        {
            bool estExist = true;
            
            foreach (Noeud nod in noeuds) 
            {
                if (nod.Id == Id) { estExist = false; }
            }
            if (estExist) 
            {   
                Noeuds.Add(new Noeud(Id));
            }
        }

        public void AjouterLien(int n1, int n2)
        {

            if(!Liens.Exists(lien => lien.Noeud1 == n1 && lien.Noeud2 == n2))
            {
                Liens.Add(new Lien());
            }
        }

    }
}
