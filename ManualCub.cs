using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace Iurcu
{
    class ManualCub
    {
        Punct A, B, C, D, E, F, G, H;
        Color[] culori = { Color.Red, Color.Beige, Color.Blue, Color.Violet, Color.Magenta, Color.Maroon, Color.White, Color.AliceBlue };
        bool verif;
        public static StreamReader f = new StreamReader("Cube_AsVertexList.txt");



        public ManualCub()
        {
            verif = true;
            string[] linie = f.ReadLine().Split(' ');
            A = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
            linie = f.ReadLine().Split(' ');
            B = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
            linie = f.ReadLine().Split(' ');
            C = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
            linie = f.ReadLine().Split(' ');
            D = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
            linie = f.ReadLine().Split(' ');
            E = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
            linie = f.ReadLine().Split(' ');
            F = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
            linie = f.ReadLine().Split(' ');
            G = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
            linie = f.ReadLine().Split(' ');
            H = new Punct(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
        }
        public void DrawCube()
        {
            f = new StreamReader("Cube_AsQuadsList.txt");
            if (!verif)
                return;
            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < 6; i++)
            {
                GL.Color3(culori[i]);
                for (int j = 0; j < 4; j++)
                {
                    string[] linie = f.ReadLine().Split(' ');
                    GL.Vertex3(int.Parse(linie[0]), int.Parse(linie[1]), int.Parse(linie[2]));
                }
            }
            GL.End();
        }
    }
}