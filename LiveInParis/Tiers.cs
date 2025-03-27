using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{
    public class Tiers
    {
        public string Mdp { get; set; }
        public string NomT { get; set; }
        public string PrenomT { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Id { get; set; }
        public string MetroLePlusProche { get; set; }

        public Tiers(string mdp, string nomT, string prenomT, string adresse, string codePostal, string ville, string email, string tel, string id, string metroLePlusProche)
        {
            this.Mdp = mdp;
            this.NomT = nomT;
            this.PrenomT = prenomT;
            this.Adresse = adresse;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.Email = email;
            this.Tel = tel;
            this.Id = id;
            this.MetroLePlusProche = metroLePlusProche;
        }
    }

}
