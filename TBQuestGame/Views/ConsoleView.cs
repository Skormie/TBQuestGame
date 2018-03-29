using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace TBQuestGame
{
    public class ConsoleView
    {
        // - Layering -
        // Layer 0 - Player
        // Layer 1 - Compiled Scene / Animated Objects Frame 1 / Objects / NPCs
        // Layer 2 - Animated Objects Frame 2
        // Layer 3 - Lootable Objects
        // Layer 4 - Background
        static public int _windowWidth = 192;
        static public int _windowHeight = 40;
        static public int _layerDepth = 5;
        public char[,,] _scene = new char[_windowWidth, _windowHeight, _layerDepth];
        public Player _player;
        public Map _map;
        public Dictionary<int, Object> _inventoryView = new Dictionary<int, Object>();
        public int lastPos;

        public ConsoleView( Player player, Map map )
        {
            _player = player;
            _map = map;
        }

        public void LoadBackground ( int stage )
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
                            SetMapInfo(column + k, row + i, 4, item);
                            SetMapInfo(column + k + 1, row + i, 4, item);
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

        public void DisplayText(int row, int column, int y_size, int x_size, int horizontal_padding, int vertical_padding, string title, string text)
        {
            string width = "";
            for (int j = 0; j < x_size; j++) width += " ";
            int size = width.Count() - horizontal_padding * 2;
            int rowr = row + vertical_padding;
            Console.ForegroundColor = ConsoleColor.White;
            for (int rowc = row; rowc < row + y_size; rowc++)
            {
                Console.SetCursorPosition(column, rowc);
                Console.Write(width);
            }
            Console.SetCursorPosition(column + vertical_padding, row + 2);
            Console.Write(title+": ");
            int i = 0;
            Console.SetCursorPosition(column + horizontal_padding, rowr);
            foreach (char item in text)
            {
                if(i >= size)
                {
                    if(rowr < row + y_size - vertical_padding) {
                        rowr++;
                        Console.SetCursorPosition(column + horizontal_padding, rowr);
                    }
                    else
                    {
                        Console.SetCursorPosition((column + x_size) - 10, rowr + 2);
                        Console.Write("[next]");
                        Console.ReadLine();
                        for (int rowc = row; rowc < row + y_size; rowc++)
                        {
                            Console.SetCursorPosition(column, rowc);
                            Console.Write(width);
                        }
                        Console.SetCursorPosition(column + 5, row + 2);
                        Console.Write(title + ": ");
                        rowr = row + vertical_padding;
                        Console.SetCursorPosition(column + horizontal_padding, rowr);
                    }
                    i = 0;
                }
                i++;
                Console.Write(item);
                Thread.Sleep(5);
            }
            Console.SetCursorPosition((column + x_size) - 10, rowr + 2);
            Console.Write("[close]");
            Console.ReadLine();

            //DisplayArea( row, column, y_size, x_size );
            _player.PlayerDisplayed = false;
            DisplayBackground();
        }

        public void DisplayInventory(int row, int column, int y_size, int x_size, int horizontal_padding, int vertical_padding, string title, string text)
        {
            string width = "";
            for (int j = 0; j < x_size; j++) width += " ";
            int size = width.Count() - horizontal_padding * 2;
            int rowc;
            Console.ForegroundColor = ConsoleColor.White;
            for (rowc = row; rowc < row + y_size; rowc++)
            {
                Console.SetCursorPosition(column, rowc);
                Console.Write(width);
            }
            Console.SetCursorPosition(column + horizontal_padding - 2, row + 2);
            Console.Write(title + ": ");
            int i = 0;
            foreach (Object item in _player.Inventory)
            {
                Console.SetCursorPosition(column + horizontal_padding, row + vertical_padding + (i * 2));
                if( row + i * 2 >= row + y_size)
                {
                    Console.SetCursorPosition((column + x_size) - 10, rowc - vertical_padding + 2);
                    Console.Write("[next]");
                    Console.ReadLine();
                    for (rowc = row; rowc < row + y_size; rowc++)
                    {
                        Console.SetCursorPosition(column, rowc);
                        Console.Write(width);
                    }
                    Console.SetCursorPosition(column + 5, row + 2);
                    Console.Write(title + ": ");
                    //rowr = row + vertical_padding;
                    i = 0;
                    Console.SetCursorPosition(column + horizontal_padding, row + vertical_padding + (i * 2));
                }
                Console.Write(item.Name);
                _inventoryView[i] = item;
                item.InventoryLoc[0] = column + horizontal_padding;
                item.InventoryLoc[1] = row + vertical_padding + (i * 2);
                i++;
            }
            Console.SetCursorPosition((column + x_size) - 10, rowc - vertical_padding + 2);
            Console.Write("[close]");
            _player.CurserPos[0] = column + horizontal_padding;
            _player.CurserPos[1] = row + vertical_padding;
            //Console.ReadLine();

            //DisplayArea( row, column, y_size, x_size );


            //_player.PlayerDisplayed = false;
            //DisplayBackground();
        }

        public void DisplayInventoryCursor(int pos)
        {
            if(lastPos != pos)
            {
                Console.SetCursorPosition(_inventoryView[lastPos].InventoryLoc[0] -5, _inventoryView[lastPos].InventoryLoc[1]);
                Console.Write("  ");
            }
            if (_inventoryView.Count() > 0 && pos < _inventoryView.Count() && pos >= 0)
            {
                Console.SetCursorPosition(_inventoryView[pos].InventoryLoc[0] -5, _inventoryView[pos].InventoryLoc[1]);
                Console.Write("->");
                lastPos = pos;
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
            Console.Write("\t\t\t ▄████████  ▄██████▄  ███▄▄▄▄      ▄████████  ▄██████▄   ▄█          ▄████████      ████████▄   ███    █▄     ▄████████    ▄████████     ███     \n" +
                          "\t\t\t███    ███ ███    ███ ███▀▀▀██▄   ███    ███ ███    ███ ███         ███    ███      ███    ███  ███    ███   ███    ███   ███    ███ ▀█████████▄ \n" +
                          "\t\t\t███    █▀  ███    ███ ███   ███   ███    █▀  ███    ███ ███         ███    █▀       ███    ███  ███    ███   ███    █▀    ███    █▀     ▀███▀▀██ \n" +
                          "\t\t\t███        ███    ███ ███   ███   ███        ███    ███ ███        ▄███▄▄▄          ███    ███  ███    ███  ▄███▄▄▄       ███            ███   ▀ \n" +
                          "\t\t\t███        ███    ███ ███   ███ ▀███████████ ███    ███ ███       ▀▀███▀▀▀          ███    ███  ███    ███ ▀▀███▀▀▀     ▀███████████     ███     \n" +
                          "\t\t\t███    █▄  ███    ███ ███   ███          ███ ███    ███ ███         ███    █▄       ███    ███  ███    ███   ███    █▄           ███     ███     \n" +
                          "\t\t\t███    ███ ███    ███ ███   ███    ▄█    ███ ███    ███ ███▌    ▄   ███    ███      ███  ▀ ███  ███    ███   ███    ███    ▄█    ███     ███     \n" +
                          "\t\t\t████████▀   ▀██████▀   ▀█   █▀   ▄████████▀   ▀██████▀  █████▄▄██   ██████████       ▀██████▀▄█ ████████▀    ██████████  ▄████████▀     ▄████▀ 64\n");
            Console.Write("\t\t\t\t\t\t\t\tProgrammed by Jason Luckhardt & Graphics by Josh Ladd.");
            Console.ReadKey();
            Console.Clear();
        }

        static int[] cColors = { 0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF, 0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF };

        public void ConsoleWritePixel(Color cValue, int j, int i)
        {
            Color[] cTable = cColors.Select(x => Color.FromArgb(x)).ToArray();
            char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 }; // 1/4, 2/4, 3/4, 4/4
            int[] bestHit = new int[] { 0, 0, 4, int.MaxValue }; //ForeColor, BackColor, Symbol, Score

            for (int rChar = rList.Length; rChar > 0; rChar--)
            {
                for (int cFore = 0; cFore < cTable.Length; cFore++)
                {
                    for (int cBack = 0; cBack < cTable.Length; cBack++)
                    {
                        int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                        int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                        int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                        int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - B) * (cValue.B - B);
                        if (!(rChar > 1 && rChar < 4 && iScore > 50000)) // rule out too weird combinations
                        {
                            if (iScore < bestHit[3])
                            {
                                bestHit[3] = iScore; //Score
                                bestHit[0] = cFore;  //ForeColor
                                bestHit[1] = cBack;  //BackColor
                                bestHit[2] = rChar;  //Symbol
                            }
                        }
                    }
                }
            }
            //Console.ForegroundColor = (ConsoleColor)bestHit[0];
            //Console.BackgroundColor = (ConsoleColor)bestHit[1];
            if ((ConsoleColor)bestHit[0] == ConsoleColor.Black && (ConsoleColor)bestHit[1] == ConsoleColor.Black)
            {
                SetMapInfo(j, i, 1, ' ');
                SetMapInfo(j + 1, i, 1, ' ');
            }
            else
            {
                SetMapInfo(j, i, 1, rList[bestHit[2] - 1]);
                SetMapInfo(j + 1, i, 1, rList[bestHit[2] - 1]);
            }
        }


        public void ConsoleWriteImage(Bitmap source, int stage)
        {
            int h = 0;
            for (int i = 0; i < source.Height; i++)
            {
                for (int j = 0; j < source.Width; j++)
                {
                    ConsoleWritePixel(source.GetPixel(j, i), j*2, i);
                    //ConsoleWritePixel(source.GetPixel(j, i));
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
            foreach (Object item in _map.Universe[stage].Objects)
                item.PrintObject(this);
        }
    }
}
