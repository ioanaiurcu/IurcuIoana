using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iurcu_1
{
    class Window3D : GameWindow
    {
        public Window3D() : base(800, 600)
        {
            VSync = VSyncMode.Off;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.ClearColor(Color.ForestGreen);

            GL.Viewport(0, 0, this.Height, this.Width);

            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            Matrix4 ochi = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref ochi);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            base.OnUpdateFrame(e);


            MouseState currentMouse = Mouse.GetState();
            KeyboardState currentKeyb = Keyboard.GetState();



            if (currentKeyb[Key.Escape])
            {
                Exit();
            }
            if (currentKeyb[Key.H])
            {
                DisplayHelp();
            }
            if (currentKeyb[Key.E])
            {
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                GL.Color3(randomColor);

            }
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            drawTriangle();

            SwapBuffers();

        }
        private void DisplayHelp()
        {
            Console.WriteLine("/n      Menu");
            Console.WriteLine("/n h - meniu ajutor");
            Console.WriteLine("/n ESC - iesire aplicatie");

        }


        public void drawTriangle()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex3(1.0f, -3.0f, -1.0f);
            GL.Vertex3(20.0f, 1.0f, -10.0f);
            GL.Vertex3(1.0f, 1.0f, 10.0f);

            GL.End();

        }
    }
}
