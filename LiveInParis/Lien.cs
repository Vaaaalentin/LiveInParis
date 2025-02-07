using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{

    public class Lien
    {
        public Noeud Noeud1 { get; set; }
        public Noeud Noeud2 { get; set; }

        public Lien(Noeud noeud1, Noeud noeud2)
        {
            this.Noeud1 = noeud1;
            this.Noeud2 = noeud2;
        }
    }
    
}
