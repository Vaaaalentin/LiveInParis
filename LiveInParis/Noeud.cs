using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{
    /// <summary>
    /// Création de la classe noeud qui représente un sommet d'un graphe 
    /// Chaque noeud est décrit par un entier
    /// </summary>
    public class Noeud
    {
        public int Id { get; set; }

        public Noeud(int id)
        {
            this.Id = id;
        }
    }
}
