using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace LiveInParis
{
    public class Dessin
    {
        public static void DessinerGraphe(Graphe graphe, string fichierImage)
        {
            int largeur = 1000;
            int hauteur = 1000;
            int rayon = 400;
            int centreX = largeur / 2;
            int centreY = hauteur / 2;
            int tailleNoeud = 40;

            Bitmap image = new Bitmap(largeur, hauteur);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);

            Point[] positions = new Point[graphe.Noeuds.Count];
            double angleStep = 2 * Math.PI / graphe.Noeuds.Count;

            for (int i = 0; i < graphe.Noeuds.Count; i++)
            {
                double angle = i * angleStep;
                int x = centreX + (int)(rayon * Math.Cos(angle));
                int y = centreY + (int)(rayon * Math.Sin(angle));
                positions[i] = new Point(x, y);
            }

            foreach (var lien in graphe.Liens)
            {
                int i1 = lien.Noeud1.Id - 1;
                int i2 = lien.Noeud2.Id - 1;
                g.DrawLine(Pens.Gray, positions[i1], positions[i2]);
            }

            foreach (var noeud in graphe.Noeuds)
            {
                int i = noeud.Id - 1;
                Point pos = positions[i];
                g.FillEllipse(Brushes.Blue, pos.X - tailleNoeud / 2, pos.Y - tailleNoeud / 2, tailleNoeud, tailleNoeud);
                g.DrawEllipse(Pens.Black, pos.X - tailleNoeud / 2, pos.Y - tailleNoeud / 2, tailleNoeud, tailleNoeud);
                g.DrawString(noeud.Id.ToString(), new Font("Arial", 12), Brushes.White, pos.X - 10, pos.Y - 10);
            }

            image.Save(fichierImage, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static void OuvrirImage(string fichierImage)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = fichierImage,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ouverture de l'image : " + ex.Message);
            }
        }

    }
}
