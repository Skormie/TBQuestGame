using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class ConsoleView
    {
        static public int _windowWidth = 160;
        static public int _windowHeight = 40;
        static public int _layerDepth = 4;
        public char[,,] _scene = new char[_windowWidth, _windowHeight, _layerDepth];
        public Player _player;
        public Map _map;

        public string background =
            "██    ██\n" +
            "█      █\n" +
            "█      █\n" +
            "██    ██\n" +
            "  ████  \n" +
            "   ██   \n" +
            "   ██   \n" +
            "  ████  \n" +
            "██    ██\n" +
            "█      █\n" +
            "█      █\n" +
            "██    ██\n" +
            "  ████  \n" +
            "   ██   \n" +
            "   ██   \n" +
            "  ████  \n" +
            "██    ██\n" +
            "█      █\n" +
            "█      █\n" +
            "██    ██\n" +
            "  ████  \n" +
            "   ██   \n" +
            "   ██   \n" +
            "  ████  \n" +
            "██    ██\n" +
            "█      █\n" +
            "█      █\n" +
            "██    ██\n" +
            "  ████  \n" +
            "   ██   \n" +
            "   ██   \n" +
            "  ████  \n" +
            "████████\n" +
            " ██  ██ \n" +
            "  ██  ██\n" +
            "█  ██  █\n";

        public System.Timers.Timer timer = new System.Timers.Timer();

        public ConsoleView( Player player, Map map )
        {
            _player = player;
            _map = map;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.Interval = 0.1;
            timer.Start();
        }

        public void CreateBackground ( int stage )
        {
            int i = 1;
            int k = 3;
            int height = _map.Universe[stage].Background.Length - _map.Universe[stage].Background.Replace("\n", "").Length;
            int width = _map.Universe[stage].Background.IndexOf('\n');
            for (int row = 0; row < _scene.GetLength(1) - height; row += height)
            {
                for (int column = 0; column < _scene.GetLength(0) - (width * 2); column += (width * 2))
                {
                    foreach (char item in _map.Universe[stage].Background)
                    {
                        if (item != '\n')
                        {
                            SetMapInfo(column + k, row + i, 1, item);
                            SetMapInfo(column + k + 1, row + i, 1, item);
                        }
                        else
                        {
                            i++;
                            k = 1;
                        }
                        k += 2;
                    }
                    i = 1;
                }
            }
            foreach (Object item in _map.Universe[stage].Objects)
                item.PrintObject(this);
        }

        public void SetupConsoleDisplay()
        {
            try
            {
                Console.SetWindowSize(_windowWidth, _windowHeight);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                if (e.ParamName == "width")
                    _windowWidth = Console.LargestWindowWidth;
                try
                {
                    Console.SetWindowSize(_windowWidth, _windowHeight);
                }
                catch (System.ArgumentOutOfRangeException b)
                {
                    if (b.ParamName == "height")
                        _windowHeight = Console.LargestWindowHeight;
                    Console.SetWindowSize(_windowWidth, _windowHeight);
                }
            }
        }

        public void SetMapInfo( int column, int row, int layer, char c )
        {
            _scene[column,row,layer] = c;
        }

        public void DisplayArea(int row, int column, int y, int x)
        {
            for (int layer = 2; layer > -1; layer--)
            {
                if (layer == 0)
                {
                    row += 1;
                    column += 1;
                    y -= 1;
                    x -= 2;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if(layer == 1)
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                for (int rowc = row; rowc < row + y; rowc++)
                {
                    Console.SetCursorPosition(column, rowc);
                    string temp = "";
                    for (int columnc = column; columnc < column + x; columnc++)
                    {
                        temp += _scene[columnc, rowc, layer];
                    }
                    Console.Write(temp);
                }
            }
        }

        public void DisplayAreaLayer(int row, int column, int y, int x, int layer = 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int rowc = row; rowc < row + y; rowc++)
            {
                Console.SetCursorPosition(column, rowc);
                string temp = "";
                for (int columnc = column; columnc < column + x; columnc++)
                {
                    temp += _scene[columnc, rowc, layer];
                }
                Console.Write(temp);
            }
        }

        //public void DisplayArea(int row, int column, int y, int x)
        //{
        //    for (int rowc = row; rowc < row + y; rowc++)
        //    {
        //        for (int columnc = column; columnc < column + x; columnc++)
        //        {
        //            Console.SetCursorPosition(columnc, rowc);
        //            for (int layer = 0; layer < 2; layer++)
        //            {
        //                if (_scene[columnc, rowc, layer] != ' ' || layer == 1)
        //                {
        //                    if (layer == 0)
        //                        Console.ForegroundColor = ConsoleColor.Blue;
        //                    Console.Write(_scene[columnc, rowc, layer]);
        //                    if (layer == 0)
        //                        Console.ForegroundColor = ConsoleColor.Gray;
        //                }
        //            }
        //            //Thread.Sleep(5);
        //        }
        //    }
        //}

        public void DisplayBackground()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int row = 0; row < _scene.GetLength(1) - 1; row++)
            {
                for (int column = 0; column < _scene.GetLength(0) - 1; column++)
                {
                    Console.SetCursorPosition(column, row);
                    if (_scene[column, row, 1] != '\0' && _scene[column, row, 1] != ' ')
                        Console.Write(_scene[column, row, 1]);
                    else
                        Console.Write(' ');
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void SplashScreen()
        {
            Console.SetCursorPosition(0, 10);
            Console.Write("\t ▄████████  ▄██████▄  ███▄▄▄▄      ▄████████  ▄██████▄   ▄█          ▄████████      ████████▄   ███    █▄     ▄████████    ▄████████     ███     \n" +
                          "\t███    ███ ███    ███ ███▀▀▀██▄   ███    ███ ███    ███ ███         ███    ███      ███    ███  ███    ███   ███    ███   ███    ███ ▀█████████▄ \n" +
                          "\t███    █▀  ███    ███ ███   ███   ███    █▀  ███    ███ ███         ███    █▀       ███    ███  ███    ███   ███    █▀    ███    █▀     ▀███▀▀██ \n" +
                          "\t███        ███    ███ ███   ███   ███        ███    ███ ███        ▄███▄▄▄          ███    ███  ███    ███  ▄███▄▄▄       ███            ███   ▀ \n" +
                          "\t███        ███    ███ ███   ███ ▀███████████ ███    ███ ███       ▀▀███▀▀▀          ███    ███  ███    ███ ▀▀███▀▀▀     ▀███████████     ███     \n" +
                          "\t███    █▄  ███    ███ ███   ███          ███ ███    ███ ███         ███    █▄       ███    ███  ███    ███   ███    █▄           ███     ███     \n" +
                          "\t███    ███ ███    ███ ███   ███    ▄█    ███ ███    ███ ███▌    ▄   ███    ███      ███  ▀ ███  ███    ███   ███    ███    ▄█    ███     ███     \n" +
                          "\t████████▀   ▀██████▀   ▀█   █▀   ▄████████▀   ▀██████▀  █████▄▄██   ██████████       ▀██████▀▄█ ████████▀    ██████████  ▄████████▀     ▄████▀ 64\n");
            Console.Write("\t\t\t\t\t\tProgrammed by Jason Luckhardt & Graphics by Josh Ladd.");
            Console.ReadKey();
            Console.Clear();
        }

        public void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            //Console.WriteLine("Timer 1 Hit...");
            //Console.WriteLine(IdleLocation[0] + " " + location[0]);

            //while(true)
                //DisplayMapInfo();

            //timer.Start();
        }
    }
}
