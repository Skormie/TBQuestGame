using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class ConsoleView
    {
        static public int windowWidth = 200;
        static public int windowHeight = 40;
        static public int layerDepth = 4;
        char[,,] map = new char[windowWidth, windowHeight, layerDepth];

        void SetupConsoleDisplay()
        {
            Console.SetWindowSize(windowWidth, windowHeight);
        }
    }
}
