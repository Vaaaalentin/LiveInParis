using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace LiveInParis
{
    /// <summary>
    /// Création de la classe Graphe qui est représenté par un ensemble de sommets et d'arêtes
    /// Les propriétés du graphe sont contenues dans une liste de noeuds et une liste de liens
    /// </summary>
    public class Graphe<T>
    {
        public List<Noeud<T>> Noeuds { get; set; }
        public List<Lien<T>> Liens { get; set; }

        public Graphe()
        {       
            Noeuds = new List<Noeud<T>>();
            Liens = new List<Lien<T>>();

        }

        //public bool Comparer(T v1, T v2)
        //{
        //    return EqualityComparer<T>.Default.Equals(v1, v2);
        //}


        /// <summary>
        /// Cette fonction permet d'ajouter un noeud au graphe
        /// Elle parcourt l'ensemble des noeuds déjà ajoutés au graphe et créé un nouveau noeud s'il n'est pas déjà dans le graphe
        /// </summary>
        /// <param name="Id">Un entier qui décrit le noeud que l'on souhaite ajouter au graphe</param>
        public void AjouterNoeud(int id, T type)
        {
            
            bool estExist = true;

            foreach (Noeud<T> nod in Noeuds)
            {
                if(nod.Id == id) { estExist = false; break; }
            }
            if (estExist)
            {
                Noeud<T> noeud = new Noeud<T>(id, type);
                Noeuds.Add(noeud);
            }

        }

        /// <summary>
        /// Cette fonction permet d'ajouter un lien entre 2 noeuds dans le graphe
        /// Pour ce faire, notre fonction repère les 2 noeuds dans la liste de noeuds du graphe
        /// Ensuite on vérifie que le lien n'a pas déjà créé et dans ce cas on l'ajoute à la liste des liens du graphe
        /// </summary>
        /// <param name="n1">Le premier noeud que l'on souhaite lier</param>
        /// <param name="n2">Le deuxième noeud que l'on souhaite lier au premier</param>
        public void AjouterLien(Noeud<T> noeudDepart, Noeud<T> noeudArrivee, int tempsTrajet, bool estMultiple)
        {

            if (noeudDepart != null && noeudArrivee != null)
            {
                //bool lienExist = false;
                


                //foreach (Lien<T> l in Liens)
                //{
                //    if (l.noeudDepart.Id == noeudDepart.Id && l.noeudArrivee.Id == noeudArrivee.Id)
                //    {
                //        lienExist = true;
                //        break;
                //    }
                //}
                if (!estMultiple)
                {
                    Liens.Add(new Lien<T>(noeudDepart, noeudArrivee, tempsTrajet, 0));
                }
                else
                {
                    Liens.Add(new Lien<T>(noeudDepart, noeudArrivee, 0, tempsTrajet));
                }
            }
        }

        internal Station FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        //public Dictionary<T, int> Maping()
        //{
        //    Dictionary<T, int> indexMaping = new Dictionary<T, int>();
        //    for (int i = 0; i < Noeuds.Count; i++)
        //    {
        //        indexMaping[Noeuds[i].Id] = i;
        //    }
        //    return indexMaping;
        //}


        /// <summary>
        /// Cette fonction permet de créer la matrice d'adjacence du graphe
        /// Elle parcourt tous les liens du graphe et place '1' dans la matrice lorsqu'il y a un lien entre 2 noeuds
        /// </summary>
        /// <returns>Une matrice d'entiers</returns>
        //public int[,] CreerMatriceAdjacence()
        //{
        //    int[,] mat = new int[Noeuds.Count, Noeuds.Count];

        //    Dictionary<T, int> indexMaping = Maping(); ///Création d'un dico pour associer chaque noeud du graphe à un ID entier 

        //    foreach (Lien<T> l in Liens)
        //    {
        //        int i1 = indexMaping[l.Noeud1.Id];
        //        int i2 = indexMaping[l.Noeud2.Id];

        //        mat[i1, i2] = 1;
        //        mat[i2, i1] = 1;
        //    }
        //    return mat;
        //}

        /// <summary>
        /// Cette fonction permet de créer la liste d'adjacence du graphe
        /// On créé dans un tableau une liste pour chaque noeud du graphe
        /// On ajoute dans cette liste tous les voisins du noeud
        /// </summary>
        /// <returns>Un tableau de listes d'entiers</returns>
        //public List<int>[] CreerListeAdjacence()
        //{
        //    List<int>[] tab = new List<int>[Noeuds.Count];

        //    Dictionary<T, int> indexMaping = Maping();


        //    for (int i = 0; i < Noeuds.Count; i++)
        //    {
        //        tab[i] = new List<int>();
        //    }

        //    foreach (Lien<T> l in Liens)
        //    {
        //        tab[indexMaping[l.Noeud2.Id]].Add(indexMaping[l.Noeud1.Id]);
        //        tab[indexMaping[l.Noeud1.Id]].Add(indexMaping[l.Noeud2.Id]);
        //    }
        //    return tab;
        //}

        /// <summary>
        /// Cette fonction effectue un parcours en largeur du graphe
        /// Pour cela on s'appuie sur la liste d'adjacence du graphe afin de faciliter le travail 
        /// La parcours en largeur se programme facilement avec une file
        /// On ajoute tous les voisins d'un sommet puis tous les voisins du premier voisin puis tous les voisins du deuxième voisin...
        /// On utilise une liste 'visite' pour ne pas passer 2 fois par les mêmes sommets 
        /// </summary>
        /// <param name="depart">Le sommet à partir duquel on réalise le parcours</param>
        //public void ParcoursLargeur(int depart)
        //{
        //    List<int> visite = new List<int>();
        //    List<int>[] parcours = CreerListeAdjacence();

        //    Queue<int> file = new Queue<int>();

        //    file.Enqueue(depart);
        //    visite.Add(depart);

        //    int compteSommet = 1;
        //    while (file.Count > 0) 
        //    {
        //        int noeud = file.Dequeue();
        //        Console.Write(noeud + " ");

        //        foreach(int n in parcours[noeud - 1])
        //        {
        //            if (!visite.Contains(n))
        //            {
        //                compteSommet++;
        //                file.Enqueue(n);
        //                visite.Add(n);
        //            }
        //        }
        //    }
        //    Console.WriteLine("\nLe parcours en largeur a visité "+ compteSommet + " sommets !");
        //}
        /// <summary>
        /// Cette fonction effectue un parcours en profondeur du graphe
        /// Pour cela on s'appuie sur la liste d'adjacence du graphe afin de faciliter le travail 
        /// La parcours en profondeur se programme facilement avec une pile
        /// On y ajoute le premier voisin du départ puis le premier voisin de ce voisin... jusqu'à devoir remonter et passer au voisin suivant
        /// On utilise une liste 'visite' pour ne pas passer 2 fois par les mêmes sommets 
        /// </summary>
        /// <param name="depart">Le sommet à partir duquel on réalise le parcours</param>
        //public void ParcoursProfondeur(int depart)
        //{
        //    List<int> visite = new List<int>();
        //    Stack<int> pile = new Stack<int>();

        //    List<int>[] parcours = CreerListeAdjacence();

        //    pile.Push(depart);

        //    while (pile.Count > 0) 
        //    { 
        //        int noeud = pile.Pop();
        //        if (!visite.Contains(noeud))
        //        {
        //            visite.Add(noeud);
        //            Console.Write(noeud + " ");

        //            foreach(int n in parcours[noeud - 1])
        //            {
        //                if (!visite.Contains(n))
        //                {
        //                    pile.Push(n);
        //                }
        //            }
        //        }

        //    }
        //}

        /// <summary>
        /// Cette méthode reprend à peu de chose près le principe du parcours en profondeur
        /// On y ajoute une condition permettant de stopper le programme à la détection d'un cycle
        /// Sinon, le programme renvoie false
        /// </summary>
        /// <param name="depart">L'entier à partir duquel on effectue le parcours</param>
        /// <returns>Un booléen indiquant la présence ou non de cycle dans le graphe</returns>
        //public bool ContientCycle(int depart)
        //{
        //    List<int> visite = new List<int>();
        //    Stack<Tuple<int, int>> pile = new Stack<Tuple<int, int>>(); 

        //    List<int>[] parcours = CreerListeAdjacence();

        //    pile.Push(new Tuple<int, int>(depart, -1)); ///On utilise -1 parce que le noeud de départ n'a pas de parent

        //    while (pile.Count > 0)
        //    {
        //        var (noeud, parent) = pile.Pop();
        //        if (!visite.Contains(noeud))
        //        {

        //            visite.Add(noeud);
        //            foreach (int voisin in parcours[noeud - 1])
        //            {
        //                if (!visite.Contains(voisin))
        //                {
        //                    pile.Push(new Tuple<int, int>(voisin, noeud));
        //                }
        //                else if (voisin == parent && depart == 1) 
        //                {
        //                    Console.Write(noeud + " ");
        //                }
        //                else if(voisin != parent )
        //                {
        //                    if (depart == 1) { Console.Write(noeud + " "); }
        //                    return true;
        //                }
        //            }
        //        }
        //    }

        //    return false;
        //}
        /// <summary>
        /// Cette fonction permet de vérifier pour chaque sommet du graphe s'il y a un cycle 
        /// Cela peut etre intéressant lorsque le graphe n'est pas connexe 
        /// </summary>
        /// <returns>Un booléen indiquant la présence d'un cycle dans le graphe </returns>
        //public bool ContientCycle()
        //{
        //    foreach (Noeud node in Noeuds)
        //    {
        //        if (!ContientCycle(node.Id))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

    }
}
