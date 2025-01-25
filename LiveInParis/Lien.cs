using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{

    public class Lien
    {
        public Noeud noeud1;
        public Noeud noeud2;

        public Lien(Noeud noeud1, Noeud noeud2)
        {
            this.noeud1 = noeud1;
            this.noeud2 = noeud2;
        }

        public int Noeud1
        {
            get; set;
        }

        public int Noeud2
        {
            get; set;
        }
    }
    
}
