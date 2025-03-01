using LiveInParis;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        //Tests classe Graphe.cs

        [TestMethod]
        public void TestAjouterNoeud()
        {
            Graphe graphe = new Graphe();

            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterNoeud(1); 

            Assert.AreEqual(2, graphe.Noeuds.Count, "Le graphe doit contenir exactement 2 nœuds.");
        }
        [TestMethod]
        public void TestAjouterLien()
        {
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);

            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(1, 2); 
            graphe.AjouterLien(2, 3); 

            Assert.AreEqual(1, graphe.Liens.Count, "Le graphe doit contenir exactement 1 lien.");
        }

        [TestMethod]
        public void TestCreerMatriceAdjacence()
        {
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterNoeud(3);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);

            int[,] matrice = graphe.CreerMatriceAdjacence();

            Assert.AreEqual(1, matrice[0, 1], "Il doit y avoir une connexion entre 1 et 2.");
            Assert.AreEqual(1, matrice[1, 2], "Il doit y avoir une connexion entre 2 et 3.");
            Assert.AreEqual(0, matrice[0, 2], "Il ne doit pas y avoir de connexion entre 1 et 3.");
        }

        [TestMethod]
        public void TestCreerListeAdjacence()
        {
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterNoeud(3);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);

            List<int>[] listeAdj = graphe.CreerListeAdjacence();

            CollectionAssert.AreEqual(new List<int> { 2 }, listeAdj[0], "1 doit être connecté à 2.");
            CollectionAssert.AreEqual(new List<int> { 1, 3 }, listeAdj[1], "2 doit être connecté à 1 et 3.");
            CollectionAssert.AreEqual(new List<int> { 2 }, listeAdj[2], "3 doit être connecté à 2.");
        }

        [TestMethod]
        public void TestContientCycle()
        {
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterNoeud(3);
            graphe.AjouterNoeud(4);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 4);
            graphe.AjouterLien(4, 1);

            bool contientCycle = graphe.ContientCycle();

            Assert.IsTrue(contientCycle, "Le graphe doit contenir un cycle.");
        }

        [TestMethod]
        public void TestNeContientPasCycle()
        {
            Graphe graphe = new Graphe();
            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterNoeud(3);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3); 

            bool contientCycle = graphe.ContientCycle();

            Assert.IsFalse(contientCycle, "Le graphe ne doit pas contenir de cycle.");
        }



    }
}