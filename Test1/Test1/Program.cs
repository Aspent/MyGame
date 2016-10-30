using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Test1
{

    class Program
    {
        static void Main(string[] args)
        {
            var resolution = SystemInformation.PrimaryMonitorSize;
            using (var game = new Game(resolution.Width, resolution.Height))
            {
                game.Run();
            }
        }
    }
}
