using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Diagnostics;

namespace TBQuestGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Controller gameController = new Controller();

            Console.ReadKey();
        }
    }
}
