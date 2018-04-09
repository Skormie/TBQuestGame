using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace TBQuestGame
{
    public class ConsoleView
    {
        #region Fields
        // - Layering -
        // Layer 0 - Player
        // Layer 1 - Compiled Scene / Animated Objects Frame 1 / Objects / NPCs
        // Layer 2 - Animated Objects Frame 2
        // Layer 3 - Lootable Objects
        // Layer 4 - Background
        public static int _windowWidth = 192;
        static public int _windowHeight = 45;
        static public int _layerDepth = 5;
        public char[,,] _scene = new char[_windowWidth, _windowHeight, _layerDepth];
        public Player _player;
        public Map _map;
        public Dictionary<int, Object> _inventoryView = new Dictionary<int, Object>();
        public int lastPos;
        public const int bkgLayer = 3;
        public const int itmLayer = 1;
        #endregion

        #region Constructors

        public ConsoleView( Player player, Map map )
        {
            _player = player;
            _map = map;
        }

        #endregion

        #region Menuing And Text
        public void DisplayText(int row, int column, int y_size, int x_size, int horizontal_padding, int vertical_padding, string title, string text)
        {
            text = text != null ? text : "Nothing is known about this item.";
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
                ClearInputBuffer();
                if (i >= size)
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


            DisplayAreaLayer(row, column, y_size, x_size);
            _player.PlayerDisplayed = false;
        }

        public void DisplayInventory(int row, int column, int y_size, int x_size, int horizontal_padding, int vertical_padding, string title)
        {
            ClearInputBuffer();
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
        }

        public int DisplayMenu(int row, int column, int y_size, int x_size, int horizontal_padding, int vertical_padding, string title, params string[] option)
        {
            ClearInputBuffer();
            string width = "";
            List<int[]> cursorPos = new List<int[]>();
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
            foreach (string item in option)
            {
                Console.SetCursorPosition(column + horizontal_padding, row + vertical_padding + (i * 2));
                if (row + i * 2 >= row + y_size)
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
                    i = 0;
                    Console.SetCursorPosition(column + horizontal_padding, row + vertical_padding + (i * 2));
                }
                Console.Write(item);
                cursorPos.Add(new int[2] { column + horizontal_padding, row + vertical_padding + (i * 2) });
                i++;
            }
            Console.SetCursorPosition((column + x_size) - 10, rowc - vertical_padding + 2);
            cursorPos.Add(new int[2] { (column + x_size) - 10, rowc - vertical_padding + 2 });
            Console.Write("[close]");
            int menuPos = 0;
            int previousPos = 0;
            bool initMenu = false;
            while (!Controller.KeyPressed(Key.Enter))
            {
                if (Controller.KeyDown(Key.Up) && menuPos > 0)
                {
                    menuPos--;
                    Thread.Sleep(90);
                }
                else if (Controller.KeyDown(Key.Down) && menuPos < option.Count())
                {
                    menuPos++;
                    Thread.Sleep(90);
                }
                DisplayMenuCursor(menuPos, cursorPos, previousPos);
                previousPos = menuPos;
                initMenu = true;
            }
            DisplayAreaLayer(row, column, y_size, x_size);
            return menuPos;
        }

        public void DisplayMenuCursor(int pos, List<int[]> cursorPos, int previousPos)
        {
            if (previousPos != pos)
            {
                Console.SetCursorPosition(cursorPos[previousPos][0] - 5, cursorPos[previousPos][1]);
                Console.Write("  ");
            }
            if (cursorPos.Count() > 0 && pos < cursorPos.Count() && pos >= 0)
            {
                Console.SetCursorPosition(cursorPos[pos][0] - 5, cursorPos[pos][1]);
                Console.Write("->");
            }
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
        #endregion

        #region Displaying Console View

        public void DisplayHealthBar()
        {
            string[] healthBar = new string[3];
            int x = 1;
            int y = 37;
            int height = 3;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < _player.MaxHealth; i++)
            {
                healthBar[0] += "▄";
                healthBar[2] += "▀";
                if(i == 0 || i == _player.MaxHealth -1)
                    healthBar[1] += "█";
                else
                    healthBar[1] += _player.Health > i ? "▓" : " ";
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(healthBar[i]);
            }
        }

        public void DisplayPlayerInfo()
        {
            int x = 1;
            int y = 36;
            int height = 3;
            Console.SetCursorPosition(x, y);
            Console.Write("Lv:" + _player.Level.ToString().PadRight(4) + _player.Name+"'s Health:");
            Console.SetCursorPosition(x, y + height + 1);
            Console.Write("Experience: "+_player.Experience+"/"+_player.NextExperience+".");
            string temp = "Gold: $"+_player.Gold+".";
            Console.SetCursorPosition(_windowWidth - temp.Length - 1, y);
            Console.Write(temp);
        }

        public void DisplayArea(int row, int column, int y, int x)
        {
            for (int layer = 3; layer > -1; layer--)
            {
                if (layer == 0)
                {
                    row += 1;
                    column += 1;
                    y -= 1;
                    x -= 2;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (layer == bkgLayer)
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                for (int rowc = row; rowc < row + y; rowc++)
                {
                    if (layer == 0)
                    {
                        Console.SetCursorPosition(column, rowc);
                        string temp = "";
                        for (int columnc = column; columnc < column + x; columnc++)
                        {
                            temp += _scene[columnc, rowc, layer];
                        }
                        int test = temp.Trim('\0', ' ').Length;
                        if (test > 0 || layer == 0)
                            Console.Write(temp);
                    }
                    else
                    {
                        if (_scene[column, rowc, layer] != '\0')
                        {
                            Console.SetCursorPosition(column, rowc);
                            Console.Write(_scene[column, rowc, layer]);
                        }
                        if (column + x < _windowWidth && _scene[column + x, rowc, layer] != '\0')
                        {
                            Console.SetCursorPosition(column + x, rowc);
                            Console.Write(_scene[column + x, rowc, layer]);
                        }
                    }
                }
            }
        }

        public void DisplayAreaLayer(int row, int column, int y, int x, int layer = bkgLayer)
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

        public void DisplayBackground()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int row = 0; row < _scene.GetLength(1) - 1; row++)
            {
                for (int column = 0; column < _scene.GetLength(0) - 1; column++)
                {
                    Console.SetCursorPosition(column, row);
                    if (_scene[column, row, bkgLayer] != '\0' && _scene[column, row, bkgLayer] != ' ')
                        Console.Write(_scene[column, row, bkgLayer]);
                    else
                        Console.Write(' ');
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayObjects()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int row = 0; row < _scene.GetLength(1) - 1; row++)
            {
                for (int column = 0; column < _scene.GetLength(0) - 1; column++)
                {
                    if (_scene[column, row, itmLayer] != '\0')
                    {
                        Console.SetCursorPosition(column, row);
                        Console.Write(_scene[column, row, itmLayer]);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayObjectsScene(int stage)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (Object item in _map.Universe[stage].Objects)
                for (int row = item.Location[0]; row < item.Location[0] + item.Height; row++)
                {
                    for (int column = item.Location[1] + 2; column < item.Location[1] + item.Width + 2; column++)
                    {
                        Console.SetCursorPosition(column, row);
                        Console.Write(_scene[column, row, item.Layer]);
                    }
                }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayObjectSceneLayer(int stage, Object item, int layer)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int row = item.Location[0]; row < item.Location[0] + item.Height; row++)
            {
                for (int column = item.Location[1] + 2; column < item.Location[1] + item.Width + 2; column++)
                {
                    Console.SetCursorPosition(column, row);
                    Console.Write(_scene[column, row, layer]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        #region Write Console Information
        public void SetMapInfo(int column, int row, int layer, char c)
        {
            _scene[column, row, layer] = c;
        }

        public void EraseLayer(int layer)
        {
            for (int row = 0; row < _scene.GetLength(1) - 1; row++)
                for (int column = 0; column < _scene.GetLength(0) - 1; column++)
                    SetMapInfo(column, row, layer, '\0');
        }

        public void EraseLayers()
        {
            Array.Clear(_scene, 0, _scene.Length);
        }

        public void EraseObjectSceneLayer(int stage, Object item)
        {
            for (int row = item.Location[0]; row < item.Location[0] + item.Height; row++)
                for (int column = item.Location[1] + 2; column < item.Location[1] + item.Width + 2; column++)
                    SetMapInfo(column, row, item.Layer, '\0');
        }

        //Code Modifed from "https://stackoverflow.com/questions/33538527/display-a-image-in-a-console-application" by @DieterMeemken accessed Thursday, March 29th, 2018.
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
                SetMapInfo(j, i, bkgLayer, ' ');
                SetMapInfo(j + 1, i, bkgLayer, ' ');
            }
            else
            {
                SetMapInfo(j, i, bkgLayer, rList[bestHit[2] - 1]);
                SetMapInfo(j + 1, i, bkgLayer, rList[bestHit[2] - 1]);
            }
        }

        public void ConsoleWriteImage(int stage)
        {
            Bitmap source = new Bitmap(@System.IO.Directory.GetCurrentDirectory() + _map.Universe[stage].Background, true);
            for (int i = 0; i < source.Height; i++)
                for (int j = 0; j < source.Width; j++)
                    ConsoleWritePixel(source.GetPixel(j, i), j*2, i);
            Console.ResetColor();
            foreach (Object item in _map.Universe[stage].Objects)
                item.PrintObject(this);
        }
        #endregion

        #region Miscellaneous Methods
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

        //Code Modifed from "https://stackoverflow.com/questions/3769770/clear-console-buffer" by gandjustas accessed Thursday, March 29th, 2018.
        public void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
        #endregion

        #region CrudCode
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

        //Antiquated Code
        //public void LoadBackground ( int stage )
        //{
        //    int i = 1;
        //    int k = 3;
        //    int height = _map.Universe[stage].Background.Length - _map.Universe[stage].Background.Replace("\n", "").Length;
        //    int width = _map.Universe[stage].Background.IndexOf('\n');
        //    for (int row = 0; row < _scene.GetLength(1) - height; row += height)
        //    {
        //        for (int column = 0; column < _scene.GetLength(0) - (width * 2); column += (width * 2))
        //        {
        //            foreach (char item in _map.Universe[stage].Background)
        //            {
        //                if (item != '\n')
        //                {
        //                    SetMapInfo(column + k, row + i, 1, item);
        //                    SetMapInfo(column + k + 1, row + i, 1, item);
        //                    SetMapInfo(column + k, row + i, 4, item);
        //                    SetMapInfo(column + k + 1, row + i, 4, item);
        //                }
        //                else
        //                {
        //                    i++;
        //                    k = 1;
        //                }
        //                k += 2;
        //            }
        //            i = 1;
        //        }
        //    }
        //    foreach (Object item in _map.Universe[stage].Objects)
        //        item.PrintObject(this);
        //}
        #endregion
    }
}
