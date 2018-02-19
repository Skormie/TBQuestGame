using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TBQuestGame
{
    public class Player
    {
        bool print = true;

        static System.Timers.Timer timer = new System.Timers.Timer();

        private List<List<string>> _sprites = new List<List<string>>()
        {
            new List<string>()
            {
                "          \n" + //Idle Right
                "   ███    \n" +
                "    ██    \n" +
                " ██ ██  █ \n" +
                " ██    █  \n" +
                "   ██ █   \n" +
                "  █  █    \n" +
                " ██  ██   \n"
            },
            new List<string>()
            {
                "          \n" + // Walk Right Startup Frame 1
                "   ███    \n" +
                "    ██    \n" +
                " ██ ██  █ \n" +
                " ██    █  \n" +
                "   ██ █   \n" +
                "  █  █    \n" +
                "  ██ ██   \n",
                "          \n" + // Walk Right Startup Frame 2
                "   ███  █ \n" +
                "    ██  █ \n" +
                "  ██ █ █  \n" +
                "  ██   █  \n" +
                "   ███    \n" +
                "  ██  █   \n" +
                "  █   ██  \n"
            },
            new List<string>()
            {
                "          \n" + // Walk Right Frame 3
                "   ███ █  \n" +
                "     █ █  \n" +
                "   ██  █  \n" +
                "   ██  █  \n" +
                " ██  █    \n" +
                "  ██ █    \n" +
                "     ██   \n",
                "          \n" + // Walk Right Frame 4
                "   ███ █  \n" +
                "     █ █  \n" +
                "   ██  █  \n" +
                "   ██  █  \n" +
                "     █    \n" +
                "   ██     \n" +
                "   ███    \n",
                "          \n" + // Walk Right Frame 5
                "   ███ █  \n" +
                "     █ █  \n" +
                "   ██  █  \n" +
                "   ██  █  \n" +
                "  ███     \n" +
                "   ██     \n" +
                "    ██    \n",
                "          \n" + // Walk Right Frame 4
                "   ███ █  \n" +
                "     █ █  \n" +
                "   ██  █  \n" +
                "   ██  █  \n" +
                "     █    \n" +
                "   ██     \n" +
                "   ███    \n"
            },
            new List<string>() {
                "          \n" + // Jumping Animation
                "   ███  █ \n" +
                " ██ ██  █ \n" +
                " ██ ██ █  \n" +
                "   █   █  \n" +
                "   ██     \n" +
                "  ██  █   \n" +
                "  █   ██  \n"
            }
        };

        //"   █████    \n"+
        //"  █████████ \n" +
        //"  ███████   \n" +
        //" ██████████ \n" +
        //" ███████████\n" +
        //" ██████████ \n" +
        //"   ███████  \n" +
        //"  ██████    \n" +
        //" ██████████ \n" +
        //"████████████\n" +
        //"████████████\n" +
        //"████████████\n" +
        //"████████████\n" +
        //"  ███  ███  \n" +
        //" ███    ███ \n" +
        //"████    ████";

        private int[] location = new int[] { 0, 0 }; // row, column
        private int[] idlelocation = new int[] { 0, 0 }; // row, column

        private int _animation;

        public int Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }


        public int[] Location
        {
            get { return location; }
            set { location = value; }
        }

        public int[] IdleLocation
        {
            get { return idlelocation; }
            set { idlelocation = value; }
        }


        public List<List<string>> Sprite
        {
            get { return _sprites; }
            set { _sprites = value; }
        }

        public Player() {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 0.1;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            //Console.WriteLine("Timer 1 Hit...");
            //Console.WriteLine(IdleLocation[0] + " " + location[0]);
            if (print && IdleLocation[0] != location[0])
            {
                IdleLocation[0] = location[0];
                IdleLocation[1] = location[1];
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    //Console.Write(IdleLocation[0] + " " + location[0]);
                    Console.SetCursorPosition(0, i);
                    Console.Write("########################################################################################################################################################################################"+ IdleLocation[0] + " " + location[0]);
                }
                print = false;
            }
            else
            {
                Console.SetCursorPosition(location[0], location[1]);
                int i = 1;
                string output = "";
                int initAni = Animation;
                foreach (string stringSprite in Sprite[Animation])
                {
                    for (int q = 0; q < 500; q++)
                    {
                        if (Animation != initAni)
                            break;
                        foreach (char item in stringSprite)
                        {
                            if (item != '\n')
                                output += item + "" + item;
                            else
                            {
                                Console.Write(output);
                                try
                                {
                                    Console.SetCursorPosition(location[0], location[1] + i);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    location[0] = Console.WindowWidth / 2;
                                    location[1] = Console.WindowHeight - 9;
                                }
                                i++;
                                output = "";
                            }
                            //output += '\n';
                        }
                        //Console.Write(output);
                        //Console.SetCursorPosition(location[0], location[1] + i);
                        i = 1;
                        //Thread.Sleep(10);
                    }
                }
                print = true;
            }
            timer.Start();
        }
    }
}
