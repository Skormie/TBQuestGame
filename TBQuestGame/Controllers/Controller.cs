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
        private Map map;
        private ConsoleView scene;
        private int stage;
        private bool object_animation = false;

        void ProgramLoop()
        {
            int count =  0;
            while (!Keyboard.IsKeyDown(Key.Escape))
            {
                count++;
                Thread.Sleep(10);
                if (KeyDown(Key.Right) && player.Location[1] < Console.WindowWidth - 38)
                {
                    player.Location[1] += 1;
                    if(player.Animation != 2)
                        player.Animation = 1;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    playerDisplayed = false;
                }
                else if (KeyDown(Key.Left) && player.Location[1] > 0)
                {
                    player.Location[1] -= 1;
                    player.Animation = 3;
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
                if(count % 100 == 0)
                {
                    foreach (Object item in map.Universe[stage].Objects)
                        scene.DisplayAreaLayer(item.Location[0] - 1, item.Location[1], item.Height, item.Width, object_animation ? 2 : 3);
                    object_animation = !object_animation;
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
            stage = 1;
            map = new Map();
            player = new Player(10, 26, 22, 9, new List<List<string>>());
            scene = new ConsoleView(player, map);
            Console.CursorVisible = false;
            scene.SetupConsoleDisplay();
            scene.SplashScreen();
            scene.CreateBackground(stage);
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
