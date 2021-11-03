using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Iurcu
{
     /// <summary>
     /// Laborator 4- citire coordonate cub din fisier
     /// </summary>
     public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Window3D wnd = new Window3D();
            wnd.Run(30.0, 0.0);
        }
    }
}
