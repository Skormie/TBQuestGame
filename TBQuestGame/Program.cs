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
        static public bool print = false;
        public char[,,] map = new char[windowWidth, windowHeight, 4];
        [STAThread]
        static void Main(string[] args)
        {
            Player player = new Player();
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetCursorPosition(90, 30);
            Console.WriteLine(Console.WindowWidth);
            Console.CursorVisible = false;
            //Console.ReadLine();
            //ConsoleKeyInfo userResponse = Console.ReadKey(true);
            player.Location[0] = Console.WindowWidth/2;
            player.Location[1] = Console.WindowHeight-9;
            while (!Keyboard.IsKeyDown(Key.Escape))
            {
                Console.CursorVisible = false;
                //ConsoleKeyInfo userResponse2 = Console.ReadKey(true);
                Thread.Sleep(10);
                if (KeyDown(Key.Right) && player.Location[0] < Console.WindowWidth-18)
                {
                    player.Location[0] += 1;
                    player.Animation = 1;
                    //spritePrint(player.Sprite[1], player.Location);
                }
                else if (KeyDown(Key.Left) && player.Location[0] > 0)
                {
                    player.Location[0] -= 1;
                    player.Animation = 2;
                    //spritePrint(player.Sprite[1], player.Location);
                }
                else
                    player.Animation = 0;
                //spritePrint(player.Sprite[0], player.Location);
                //userResponse2 = userResponse;
                //Console.Write(spritePrint(player.Sprite, player.Location));
                //Console.Clear();
            }
        }

        //static void printBackground()
        //{
        //    for (int i = 0; i < Console.WindowHeight; i++)
        //    {
        //        print = true;
        //        Console.SetCursorPosition(0, i);
        //        Console.Write("#############################################################################################");
        //    }
        //    print = false;
        //}

        static void spritePrint(List<string> sprite, int[] location)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.SetCursorPosition(location[0], location[1]);
            int i = 1;
            string output = "";
            foreach (string stringSprite in sprite)
            {
                foreach (char item in stringSprite)
                {
                    if (item != '\n')
                        output += item + "" + item;
                    else
                    {
                        Console.Write(output);
                        Console.SetCursorPosition(location[0], location[1] + i);
                        i++;
                        output = "";
                    }
                    //output += '\n';
                }
                Console.Write(output);
                Console.SetCursorPosition(location[0], location[1] + i);
                i = 1;
                Thread.Sleep(1);
            }
        }
        static bool KeyDown(Key pKey)
        {
            if (Keyboard.IsKeyDown(pKey))
                return true;
            return false;
        }
    }
}
