using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{
    /// <summary>
    /// Création de la classe lien qui représente une arête entre 2 sommets
    /// Un lien est représenté par 2 noeuds distincts
    /// </summary>
    public class Lien<T> 
    {
        public Noeud<T> noeudDepart { get; set; }
        public Noeud<T> noeudArrivee { get; set; }
        public int tempsTrajet { get; set; }
        public int tempsCorresp { get; set; }
        

        public Lien(Noeud<T> noeudDepart, Noeud<T> noeudArrivee, int tempsTrajet, int tempsCorresp)
        {
            this.noeudDepart = noeudDepart;
            this.noeudArrivee = noeudArrivee;
            this.tempsTrajet = tempsTrajet;
            this.tempsCorresp = tempsCorresp;

        }
        
        public void InfoLien()
        {
            if (noeudDepart.type is Station stationDepart && noeudArrivee.type is Station stationArrivee)
            {
                if (tempsTrajet > 0) { 
                    Console.WriteLine("La station " + stationDepart.libStation +
                        " est reliée à la station " + stationArrivee.libStation +
                        " en " + tempsTrajet + " min");
                }
                else
                {
                    Console.WriteLine("La station " + stationDepart.libStation +
                         " est reliée à elle même mais sur la ligne "+ stationArrivee.libLigne+ " en " + tempsCorresp + " min");
                }
                
            }
            
        }
    }
    
}
