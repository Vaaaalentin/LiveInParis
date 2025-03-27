using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;

namespace LiveInParis
{
    public class BDD
    {
        private string connexionString { get; set; }
        private MySqlConnection maConnexion;
        public BDD(string connexionString)
        {
            this.connexionString = connexionString;
            Connexion();
        }

        public MySqlConnection MaConnexion
        {
            get { return maConnexion; }
            set {  maConnexion = value; }
        }

        public void Connexion()
        {
            try
            {
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("Connexion réussie à la base de données.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.ToString());
            }
        }

        public void Deconnexion()
        {
            try
            {
                if (maConnexion != null && maConnexion.State == System.Data.ConnectionState.Open)
                {
                    maConnexion.Close();
                    Console.WriteLine("Déconnexion réussie de la base de données.");
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Déconnexion impossible : " + e.ToString());
            }
        }

        public void ExecuterRequete(string requete)
        {
            MySqlCommand cmd = maConnexion.CreateCommand();
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Requête exécutée.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de l'exécution : " + e.ToString());
            }
            cmd.Dispose();
        }

        public static void ExecuterRequeteSelect(string requete, MySqlConnection maConnexion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(requete, maConnexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                { 
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetName(i),-20} ");
                    }
                    Console.WriteLine();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetValue(i),-20} ");
                        }
                        Console.WriteLine();
                    }

                    reader.Close();
                }
                else
                {
                    Console.WriteLine("Aucun résultat trouvé ou erreur dans la requête.");
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + e.ToString());
            }
        }

        public void AfficherClientAsc()
        {
            Console.WriteLine("Clients triés par ordre alphabétique");
            ExecuterRequeteSelect("SELECT ID,NOMT,PRENOMT FROM CLIENT ORDER BY NOMT ASC,PRENOMT ASC",maConnexion);
        }

        public void AfficherClientRue()
        {
            Console.WriteLine("Clients triés par leurs adresses");
            ExecuterRequeteSelect("SELECT ID,NOMT,PRENOMT,ADRESSE FROM CLIENT ORDER BY ADRESSE ASC", maConnexion);
        }

        public void AfficherClientAchat()
        {
            Console.WriteLine("Clients triés par achats");
            ExecuterRequeteSelect("SELECT C.ID,NOMT,PRENOMT FROM CLIENT C JOIN COMMANDE CO ON C.ID = CO.ID GROUP BY C.ID ORDER BY SUM(CO.PRIXTOTAL) DESC", maConnexion);
        }

        public void AjouterClient()
        {
            Console.WriteLine("Ajouter Client : ");
            Console.Write("ID : ");
            string id = Console.ReadLine();
            Console.Write("ID Livraison : ");
            string idLivraison = Console.ReadLine();
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine();
            Console.Write("Code Postal : ");
            string codePostal = Console.ReadLine();
            Console.Write("Ville : ");
            string ville = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();
            Console.Write("Métro le plus proche : ");
            string metroLePlusProche = Console.ReadLine();
            Console.Write("Nombre de commandes : ");
            int nbDeCommandes = int.Parse(Console.ReadLine());
            Console.Write("Note (0 à 5) : ");
            int note = int.Parse(Console.ReadLine());
            note = Math.Max(0, Math.Min(5, note)); 
            Console.Write("Type de régime : ");
            string typeDeRegime = Console.ReadLine();
            Console.Write("Mot de passe : ");
            string mdp = Console.ReadLine();

            string requete = "INSERT INTO CLIENT (ID, IDLIVRAISON, NBDECOMMANDES, NOTE, TYPEDEREGIME, MDP, " +
                            "NOMT, PRENOMT, ADRESSE, CODEPOSTAL, VILLE, EMAIL, TEL, METROLEPLUSPROCHE) " +
                            "VALUES (@ID, @IDLIVRAISON, @NBDECOMMANDES, @NOTE, @TYPEDEREGIME, @MDP, " +
                            "@NOMT, @PRENOMT, @ADRESSE, @CODEPOSTAL, @VILLE, @EMAIL, @TEL, @METROLEPLUSPROCHE)";

            MySqlCommand cmd = new MySqlCommand(requete, maConnexion);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@IDLIVRAISON", idLivraison);
            cmd.Parameters.AddWithValue("@NBDECOMMANDES", nbDeCommandes);
            cmd.Parameters.AddWithValue("@NOTE", note);
            cmd.Parameters.AddWithValue("@TYPEDEREGIME", typeDeRegime);
            cmd.Parameters.AddWithValue("@MDP", mdp); 
            cmd.Parameters.AddWithValue("@NOMT", nom);
            cmd.Parameters.AddWithValue("@PRENOMT", prenom);
            cmd.Parameters.AddWithValue("@ADRESSE", adresse);
            cmd.Parameters.AddWithValue("@CODEPOSTAL", codePostal);
            cmd.Parameters.AddWithValue("@VILLE", ville);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@TEL", telephone);
            cmd.Parameters.AddWithValue("@METROLEPLUSPROCHE", metroLePlusProche);

            cmd.ExecuteNonQuery();
        }

        public void SupprimerClient()
        {
            Console.WriteLine("Id Client à supprimer : ");
            string id = Console.ReadLine();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM CLIENT WHERE ID = @ID",maConnexion);
            cmd.Parameters.AddWithValue("@ID",id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Client supprimé avec succès");
        }

        public void ModifierClient()
        {
            Console.WriteLine("Modifier Client : ");
            Console.Write("ID : ");
            string id = Console.ReadLine();
            Console.Write("ID Livraison : ");
            string idLivraison = Console.ReadLine();
            Console.Write("Nombre de Commandes : ");
            string nbDeCommandes = Console.ReadLine();
            Console.Write("Note : ");
            string note = Console.ReadLine();
            Console.Write("Type de Régime : ");
            string typeDeRegime = Console.ReadLine();
            Console.Write("Mot de passe : ");
            string mdp = Console.ReadLine();
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine();
            Console.Write("Code Postal : ");
            string codePostal = Console.ReadLine();
            Console.Write("Ville : ");
            string ville = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();
            Console.Write("Métro le plus proche : ");
            string metroLePlusProche = Console.ReadLine();

            string requete = "UPDATE CLIENT SET IDLIVRAISON = @IDLIVRAISON, NBDECOMMANDES = @NBDECOMMANDES, NOTE = @NOTE, TYPEDEREGIME = @TYPEDEREGIME, MDP = @MDP, NOMT = @NOMT, PRENOMT = @PRENOMT, ADRESSE = @ADRESSE, CODEPOSTAL = @CODEPOSTAL, VILLE = @VILLE, EMAIL = @EMAIL, TEL = @TEL, METROLEPLUSPROCHE = @METROLEPLUSPROCHE WHERE ID = @ID";
            MySqlCommand cmd = new MySqlCommand(requete, maConnexion);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@IDLIVRAISON", idLivraison);
            cmd.Parameters.AddWithValue("@NBDECOMMANDES", nbDeCommandes);
            cmd.Parameters.AddWithValue("@NOTE", note);
            cmd.Parameters.AddWithValue("@TYPEDEREGIME", typeDeRegime);
            cmd.Parameters.AddWithValue("@MDP", mdp);
            cmd.Parameters.AddWithValue("@NOMT", nom);
            cmd.Parameters.AddWithValue("@PRENOMT", prenom);
            cmd.Parameters.AddWithValue("@ADRESSE", adresse);
            cmd.Parameters.AddWithValue("@CODEPOSTAL", codePostal);
            cmd.Parameters.AddWithValue("@VILLE", ville);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@TEL", telephone);
            cmd.Parameters.AddWithValue("@METROLEPLUSPROCHE", metroLePlusProche);
            cmd.ExecuteNonQuery();
        }

        public void AjouterCuisinier()
        {
            Console.WriteLine("Ajouter Cuisinier : ");
            Console.Write("ID : ");
            string id = Console.ReadLine();
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine();
            Console.Write("Code Postal : ");
            string codePostal = Console.ReadLine();
            Console.Write("Ville : ");
            string ville = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();
            Console.Write("Métro le plus proche : ");
            string metroLePlusProche = Console.ReadLine();

            string requete = "INSERT INTO CLIENT (ID, NOMT, PRENOMT, ADRESSE, CODEPOSTAL, VILLE, EMAIL, TEL, METROLEPLUSPROCHE) " +
                            "VALUES (@ID, @NOMT, @PRENOMT, @ADRESSE, @CODEPOSTAL, @VILLE, @EMAIL, @TEL, @METROLEPLUSPROCHE)";
            MySqlCommand cmd = new MySqlCommand(requete, maConnexion);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NOMT", nom);
            cmd.Parameters.AddWithValue("@PRENOMT", prenom);
            cmd.Parameters.AddWithValue("@ADRESSE", adresse);
            cmd.Parameters.AddWithValue("@CODEPOSTAL", codePostal);
            cmd.Parameters.AddWithValue("@VILLE", ville);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@TEL", telephone);
            cmd.Parameters.AddWithValue("@METROLEPLUSPROCHE", metroLePlusProche);

            cmd.ExecuteNonQuery();
        }

        public void SupprimerCuisinier()
        {

        }

        public void ModifierCuisinier()
        {

        }
    }
}
