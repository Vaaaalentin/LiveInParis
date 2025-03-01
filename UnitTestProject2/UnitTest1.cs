using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiveInParis;
using System;

namespace LiveInParis
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAjouterNoeud()
        {
            Graphe graphe = new Graphe();

            graphe.AjouterNoeud(1);
            graphe.AjouterNoeud(2);
            graphe.AjouterNoeud(1); // Test d'ajout d'un nœud déjà existant

            // Assert
            Assert.AreEqual(2, graphe.Noeuds.Count, "Le graphe doit contenir exactement 2 nœuds.");
        }
    }
}
