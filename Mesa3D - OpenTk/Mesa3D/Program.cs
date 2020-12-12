using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Mesa3D
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(500, 500);
            //window.Run(1.0 / 60.0);
            Game gm = new Game(window);
        }
    }
}
