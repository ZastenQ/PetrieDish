using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using PetrieDish;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetrieDishGL
{
    class PetrieDishGL
    {
        private const Int32 DishSize = 100;
        private const float DEG2RAD = 3.14159f / 180f;

        [STAThread]
        static void Main(string[] args)
        {
            Dish CurrentDish = new Dish(100, 5, 0.66);

            using (GameWindow game = new GameWindow(800, 800))
            {
                game.Load += (sender, e) =>
                {
                    // setup settings, load textures, sounds
                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };

                game.UpdateFrame += (sender, e) =>
                {
                    // add game logic, input handling
                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                };

                game.RenderFrame += (sender, e) =>
                {
                    // render graphics
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(0, DishSize, 0, DishSize, 0.0, 4.0);
                    DrawDish();
                    DrawCluster(CurrentDish);
                    DrawBacteria(CurrentDish);

                    game.SwapBuffers();
                    CurrentDish.LifeCicle();
                };

                // Run the game at 60 updates per second
                game.Run(60.0);
            }
        }

        static void DrawDish()
        {
            GL.ClearColor(Color.Ivory);
        }

        static void DrawCluster(Dish dish)
        {
            Int32 clusterSize = ValueToPoint(0, dish.DishDimension, dish.Cluster.ClusterDimension, DishSize);

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Gray);
            for (Int32 i = 0; i < dish.Cluster.CntCluster; i++)
            {
                GL.Vertex2(i * clusterSize, 0.0f);
                GL.Vertex2(i * clusterSize, DishSize);
                GL.Vertex2(0.0f, i * clusterSize);
                GL.Vertex2(DishSize, i * clusterSize);
            }

            GL.End();
        }

        static void DrawBacteria(Dish dish)
        {

            foreach (Bacterium b in dish.Bacteria)
            {
                Int32 pX = ValueToPoint(0, dish.DishDimension, b.CurrentPoint.X, DishSize);
                Int32 pY = ValueToPoint(0, dish.DishDimension, b.CurrentPoint.Y, DishSize);

                DrawCircle(0.5f, pX, pY);
            }
        }

        static void DrawCircle(float radius, float pX, float pY)
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color.Red);

            for (int i = 0; i <= 360; i++)
            {
                float degInRad = i * DEG2RAD;
                GL.Vertex2(Math.Cos(degInRad) * radius + pX, Math.Sin(degInRad) * radius + pY);
            }

            GL.End();
        }

        public static Int32 ValueToPoint(Double x1, Double x2, Double x, Int32 H)
        {
            return Convert.ToInt32((x - x1) * H / (x2 - x1));
        }
    }
}
