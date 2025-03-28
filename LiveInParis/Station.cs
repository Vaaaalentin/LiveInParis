using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveInParis
{
    internal class Station
    {
        public int IdStation { get; set; }
        public int libLigne { get; set; }
        public string libStation { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string nomCommune { get; set; }
        public int codeCommune { get; set; }

        public Station (int idStation, int libLigne, string libStation, double longitude, double latitude, string nomCommune, int codeCommune)
        {
            this.IdStation = idStation;
            this.libLigne = libLigne;
            this.libStation = libStation;
            this.longitude = longitude;
            this.latitude = latitude;
            this.nomCommune = nomCommune;
            this.codeCommune = codeCommune;
        }

        public void InfoStation()
        {
            Console.WriteLine("La station : " + IdStation + ", " + libStation +
                " est située sur la ligne " + libLigne + ".");
        }
    }
}
