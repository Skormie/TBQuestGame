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
    class Controller
    {
        private bool playerDisplayed = false;
        private Player player;
        private ConsoleView scene;

        void ProgramLoop()
        {
            while (!Keyboard.IsKeyDown(Key.Escape))
            {
                Thread.Sleep(10);
                if (KeyDown(Key.Right) && player.Location[1] < Console.WindowWidth - 38)
                {
                    player.Location[1] += 1;
                    player.Animation = 1;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    playerDisplayed = false;
                }
                else if (KeyDown(Key.Left) && player.Location[1] > 0)
                {
                    player.Location[1] -= 1;
                    player.Animation = 2;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    playerDisplayed = false;
                }
                else if (!playerDisplayed)
                {
                    player.Animation = 0;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    playerDisplayed = true;
                }
            }
        }

        public Controller()
        {
            InitializeGame();

            ProgramLoop();
        }

        private void InitializeGame()
        {
            player = new Player(10, 25, 22, 9, new List<List<string>>());
            Object torch = new Object(100, 10, 22, 9,
                new List<List<string>>() {
                    new List<string>() {
                        "\0        \n" +
                        "\0   █    \n" +
                        "\0  █ █   \n" +
                        "\0 ███ █  \n" +
                        "\0██    █ \n" +
                        "\0 █   █  \n" +
                        "\0  █ █   \n" +
                        "\0███████ \n" +
                        "\0  ███   \n" +
                        "\0        \n"
                    }
                }
            );
            scene = new ConsoleView(player);
            //Console.CursorVisible = false;
            scene.SetupConsoleDisplay();
            scene.SplashScreen();
            scene.CreateBackground();
            torch.PrintObject(scene, 1);
            scene.DisplayBackground();
            player.PrintObject(scene);
        }

        static bool KeyDown(Key pKey)
        {
            if (Keyboard.IsKeyDown(pKey))
                return true;
            return false;
        }
    }
}
