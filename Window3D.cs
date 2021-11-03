using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace Iurcu
{
    class Window3D : GameWindow
    {
        Axes xyz;
        ManualCub trg;

        KeyboardState lastKeyPress;
        private const int XYZ_SIZE = 75;

        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            DisplayHelp();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            xyz = new Axes();
            trg = new ManualCub();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (mouse[MouseButton.Left])
            {
                //Console.WriteLine("Click non-accelerat (" + mouse.X + "," + mouse.Y + "); accelerat (" + Mouse.X + "," + Mouse.Y + ")");
                //ntPtr pix = new IntPtr();
                //GL.ReadPixels(Mouse.X, Mouse.Y, 1, 1, PixelFormat.Rgb, PixelType.Int, pix);
                Console.WriteLine("Pixel colour (" + IntPtr.Size + " - 32 or 64 bits process);");
                Console.WriteLine("");
            }


            // Se utilizeaza mecanismul de control input oferit de OpenTK (include perifcerice multiple, inclusiv
            // pentru gaminig - gamepads, joysticks, etc.).
            if (keyboard[Key.Escape])
            {
                Exit();
                return;
            }

            if (keyboard[Key.P] && !keyboard.Equals(lastKeyPress))
            {
                // Ascundere comandată, prin apăsarea unei taste - cu verificare de remanență! Timpul de reacție
                // uman << calculator.

                xyz.ToggleVisibility();
            }

            if (keyboard[Key.H] && !lastKeyPress[Key.H])
            {
                DisplayHelp();
            }




            lastKeyPress = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            xyz.DrawMe();

            trg.DrawCube();

            SwapBuffers();
        }
        private void DisplayHelp()
        {
            Console.WriteLine("\n Meniu");
            Console.WriteLine(" H- meniul");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine("\n============================Valorile RGB===============================");
            


        }

    }
}