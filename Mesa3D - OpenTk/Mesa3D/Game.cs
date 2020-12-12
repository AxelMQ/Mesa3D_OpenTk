using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Mesa3D
{
    public class Game
    {
        double x = 0.0;
        GameWindow window;
        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }
        void Start()
        {
            window.Load += loaded;
            window.Resize += resize;
            window.RenderFrame += renderF;
            window.Run(1.0 / 60.0);
        }

        void resize(object ob, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 matrix = Matrix4.Perspective(45.0f, window.Width / window.Height, 1.0f, 100f); // probando el 45
            GL.LoadMatrix(ref matrix);

            GL.MatrixMode(MatrixMode.Modelview);

        }

        void renderF(Object o, EventArgs e)
        {
            GL.LoadIdentity();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PushMatrix();  //***

            GL.Translate(0.0, 0.0, -45.0);

            //rotar
            GL.Rotate(x, 0.5, 1.5, 0.1);
            GL.Rotate(x, 0.5, 1.5, 0.1);

            //GL.Scale(1.5, 0.1, 1.0);
            draw_Base();
            draw_1raPata();
            draw_2daPata();
            draw_3raPata();
            draw_4taPata();

            GL.PopMatrix(); //***

            window.SwapBuffers();

            //ROTACION
            x += 1.0; // cada segundo rotara(1seg) mas alto, mas rapido
            if (x > 360)
                x -= 360;

        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.1f, 0.1f, 0.1f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            //LIGHTING
            GL.Enable(EnableCap.Lighting);

            float[] light_position = {20,20,80};
            float[] light_diffuse = {0.4f, 0.1f, 0.0f};
            float[] light_ambient = {0.4f, 0.1f, 0.0f};
            GL.Light(LightName.Light0, LightParameter.Position, light_position);
            GL.Light(LightName.Light0,LightParameter.Diffuse, light_diffuse);
            GL.Light(LightName.Light0, LightParameter.Ambient, light_ambient);
            
            GL.Enable(EnableCap.Light0);

   

        }

        void draw_Base(){
            /*
             * ============ BASE =============
             */

             GL.Begin(BeginMode.Quads);
            GL.Color3(1.0, 0.0, 1.0);
            //Front
            GL.Normal3(0.0, 0.0, 1.0);
            //GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-15.0, 1.0, 15.0);
            GL.Vertex3(-15.0, 1.0, -15.0);
            GL.Vertex3(-15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, -1.0, 15.0);
            //Black
            GL.Normal3(0.0, 0.0, -1.0);
            //GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(15.0, 1.0, 15.0);
            GL.Vertex3(15.0, 1.0, -15.0);
            GL.Vertex3(15.0, -1.0, -15.0);
            GL.Vertex3(15.0, -1.0, 15.0);
            //Top
            GL.Normal3(0.0, 1.0, 0.0);
            //GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(15.0, -1.0, 15.0);
            GL.Vertex3(15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, -1.0, 15.0);
            //Bottom
            GL.Normal3(0.0, -1.0, 0.0);
            //GL.Color3(1.0, 0.0, 0.0); // rojo 
            GL.Vertex3(15.0, 1.0, 15.0);
            GL.Vertex3(15.0, 1.0, -15.0);
            GL.Vertex3(-15.0, 1.0, -15.0);
            GL.Vertex3(-15.0, 1.0, 15.0);
            //Right
            GL.Normal3(1.0, 0.0, 0.0);
            //GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(15.0, 1.0, -15.0);
            GL.Vertex3(15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, 1.0, -15.0);
            //Left
            GL.Normal3(-1.0, 0.0, 0.0);
            //GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(15.0, 1.0, 15.0);
            GL.Vertex3(15.0, -1.0, 15.0);
            GL.Vertex3(-15.0, -1.0, 15.0);
            GL.Vertex3(-15.0, 1.0, 15.0);

            GL.End();
        }

        void draw_1raPata(){
            // ***
            /*
             * ======================
             *       1ra. Pata
             * =======================
             */

             GL.Begin(BeginMode.Quads);

            //Front
            GL.Normal3(0.0, 0.0, 1.0);
            //GL.Color3(1.0, 1.0, 1.0);
            GL.Vertex3(-15.0, -1.0, 15.0);
            GL.Vertex3(-15.0, -1.0, -11.5);
            GL.Vertex3(-13.0, -1.0, -11.5);
            GL.Vertex3(-13.0, -1.0, 15.0);
            
            //Lado1
            GL.Normal3(0.0, 0.0, -1.0);
            //GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(-15.0, -20.0, 15.0);
            GL.Vertex3(-15.0, -1.0, 15.0);
            GL.Vertex3(-15.0, -1.0, 11.5);
            GL.Vertex3(-15.0, -20.0, 11.5);
            
            //abajo
            GL.Normal3(0.0, 1.0, 0.0);
            //GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(-15.0, -20.0, 15.0);
            GL.Vertex3(-15.0, -20.0, 11.5);
            GL.Vertex3(-13.0, -20.0, 11.5);
            GL.Vertex3(-13.0, -20.0, 15.0);
            
            //Bottom
            GL.Normal3(0.0, -1.0, 0.0);
            //GL.Color3(1.0, 0.0, 0.0); // rojo 
            GL.Vertex3(-13.0, -20.0, 15.0);
            GL.Vertex3(-13.0, -20.0, 11.5);
            GL.Vertex3(-13.0, -1.0, 11.5);
            GL.Vertex3(-13.0, -1.0, 15.0);

            
            //Right
            GL.Normal3(1.0, 0.0, 0.0);
            //GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(-15.0, -1.0, 15.0);
            GL.Vertex3(-15.0, -20.0, 15.0);
            GL.Vertex3(-13.0, -20.0, 15.0);
            GL.Vertex3(-13.0, -1.0, 15.0);
            
            //Left
            GL.Normal3(-1.0, 0.0, 0.0);
            //GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(-15.0, -1.0, 11.5);
            GL.Vertex3(-15.0, -20.0, 11.5);
            GL.Vertex3(-13.0, -20.0, 11.5);
            GL.Vertex3(-13.0, -1.0, 11.5);
  
            GL.End();
        }

        void draw_2daPata()
        {
            /*
             * ======================
             *    2da. Pata
             * =======================
             */GL.Begin(BeginMode.Quads);

            GL.Normal3(0.0, 0.0, 1.0);
            //GL.Color3(1.0, 1.0, 1.0);
            GL.Vertex3(15.0, -1.0, 15.0);
            GL.Vertex3(15.0, -1.0, -11.5);
            GL.Vertex3(13.0, -1.0, -11.5);
            GL.Vertex3(13.0, -1.0, 15.0);
            
            //Lado1
            GL.Normal3(0.0, 0.0, -1.0);
            //GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(15.0, -20.0, 15.0);
            GL.Vertex3(15.0, -1.0, 15.0);
            GL.Vertex3(15.0, -1.0, 11.5);
            GL.Vertex3(15.0, -20.0, 11.5);
            
            //abajo
            GL.Normal3(0.0, 1.0, 0.0);
            //GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(15.0, -20.0, 15.0);
            GL.Vertex3(15.0, -20.0, 11.5);
            GL.Vertex3(13.0, -20.0, 11.5);
            GL.Vertex3(13.0, -20.0, 15.0);
            
            //Bottom
            GL.Normal3(0.0, -1.0, 0.0);
            //GL.Color3(1.0, 0.0, 0.0); // rojo 
            GL.Vertex3(13.0, -20.0, 15.0);
            GL.Vertex3(13.0, -20.0, 11.5);
            GL.Vertex3(13.0, -1.0, 11.5);
            GL.Vertex3(13.0, -1.0, 15.0);

            
            //Right
            GL.Normal3(1.0, 0.0, 0.0);
            //GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(15.0, -1.0, 15.0);
            GL.Vertex3(15.0, -20.0, 15.0);
            GL.Vertex3(13.0, -20.0, 15.0);
            GL.Vertex3(13.0, -1.0, 15.0);
            
            //Left
            GL.Normal3(-1.0, 0.0, 0.0);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(15.0, -1.0, 11.5);
            GL.Vertex3(15.0, -20.0, 11.5);
            GL.Vertex3(13.0, -20.0, 11.5);
            GL.Vertex3(13.0, -1.0, 11.5);

            GL.End();
        }

        void draw_3raPata()
        {
            /*
             * ======================
             *    3ra. Pata
             * =======================
             */GL.Begin(BeginMode.Quads);
            GL.Normal3(0.0, 0.0, 1.0);
           // GL.Color3(1.0, 1.0, 1.0);
            GL.Vertex3(15.0, -1.0, -15.0);
            GL.Vertex3(15.0, -1.0, -11.5);
            GL.Vertex3(13.0, -1.0, -11.5);
            GL.Vertex3(13.0, -1.0, -15.0);
            
            //Lado1
            GL.Normal3(0.0, 0.0, -1.0);
            //GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(15.0, -20.0, -15.0);
            GL.Vertex3(15.0, -1.0, -15.0);
            GL.Vertex3(15.0, -1.0, -11.5);
            GL.Vertex3(15.0, -20.0, -11.5);
            
            //abajo
            GL.Normal3(0.0, 1.0, 0.0);
            //GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(15.0, -20.0, -15.0);
            GL.Vertex3(15.0, -20.0, -11.5);
            GL.Vertex3(13.0, -20.0, -11.5);
            GL.Vertex3(13.0, -20.0, -15.0);
            
            //Bottom
            GL.Normal3(0.0, -1.0, 0.0);
            //GL.Color3(1.0, 0.0, 0.0); // rojo 
            GL.Vertex3(13.0, -20.0, -15.0);
            GL.Vertex3(13.0, -20.0, -11.5);
            GL.Vertex3(13.0, -1.0, -11.5);
            GL.Vertex3(13.0, -1.0, -15.0);

            
            //Right
            GL.Normal3(1.0, 0.0, 0.0);
            //GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(15.0, -1.0, -15.0);
            GL.Vertex3(15.0, -20.0, -15.0);
            GL.Vertex3(13.0, -20.0, -15.0);
            GL.Vertex3(13.0, -1.0, -15.0);
            
            //Left
            GL.Normal3(-1.0, 0.0, 0.0);
            //GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(15.0, -1.0, -11.5);
            GL.Vertex3(15.0, -20.0, -11.5);
            GL.Vertex3(13.0, -20.0, -11.5);
            GL.Vertex3(13.0, -1.0, -11.5);

            GL.End();
        }

        void draw_4taPata()
        {
            /*
             * ======================
             *    4ta. Pata
             * =======================
             */GL.Begin(BeginMode.Quads);

            GL.Normal3(0.0, 0.0, 1.0);
            //GL.Color3(1.0, 1.0, 1.0);
            GL.Vertex3(-15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, -1.0, -11.5);
            GL.Vertex3(-13.0, -1.0, -11.5);
            GL.Vertex3(-13.0, -1.0, -15.0);
            
            //Lado1
            GL.Normal3(0.0, 0.0, -1.0);
            //GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(-15.0, -20.0, -15.0);
            GL.Vertex3(-15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, -1.0, -11.5);
            GL.Vertex3(-15.0, -20.0, -11.5);
            
            //abajo
            GL.Normal3(0.0, 1.0, 0.0);
            //GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(-15.0, -20.0, -15.0);
            GL.Vertex3(-15.0, -20.0, -11.5);
            GL.Vertex3(-13.0, -20.0, -11.5);
            GL.Vertex3(-13.0, -20.0, -15.0);
            
            //Bottom
            GL.Normal3(0.0, -1.0, 0.0);
            GL.Color3(1.0, 0.0, 0.0); // rojo 
            GL.Vertex3(-13.0, -20.0, -15.0);
            GL.Vertex3(-13.0, -20.0, -11.5);
            GL.Vertex3(-13.0, -1.0, -11.5);
            GL.Vertex3(-13.0, -1.0, -15.0);

            
            //Right
            GL.Normal3(1.0, 0.0, 0.0);
            //GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(-15.0, -1.0, -15.0);
            GL.Vertex3(-15.0, -20.0, -15.0);
            GL.Vertex3(-13.0, -20.0, -15.0);
            GL.Vertex3(-13.0, -1.0, -15.0);
            
            //Left
            GL.Normal3(-1.0, 0.0, 0.0);
            //GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(-15.0, -1.0, -11.5);
            GL.Vertex3(-15.0, -20.0, -11.5);
            GL.Vertex3(-13.0, -20.0, -11.5);
            GL.Vertex3(-13.0, -1.0, -11.5);

            GL.End();
        }

        
    }
        
}
