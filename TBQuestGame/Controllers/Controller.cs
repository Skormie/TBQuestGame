using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Diagnostics;
using System.Drawing;

namespace TBQuestGame
{
    class Controller
    {
        private Player player;
        private Map map;
        private ConsoleView scene;
        private int stage;
        private int inventoryPos = 0;

        void ProgramLoop()
        {
            int count =  0;
            while (!Keyboard.IsKeyDown(Key.Escape))
            {
                count++;
                Thread.Sleep(10);

                if (player.InventoryInit)
                {
                    ManagePlayerInventory();
                    continue;
                }

                if (count % 100 == 0)
                {
                    foreach (Object item in map.Universe[stage].Objects)
                        scene.DisplayAreaLayer(item.Location[0], item.Location[1] + 2, item.Height, item.Width, item.GetObjectFrame());
                    player.PlayerDisplayed = false;
                }

                if (KeyDown(Key.I))
                {
                    player.InventoryInit = true;
                    scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory", "");
                }

                if (KeyDown(Key.Space))
                    scene.DisplayText(2, 27, 13, 100, 8, 5, "NPC NAME", "THIS IS SOME TEXT.");

                if(KeyDown(Key.P))
                    SearchPlayerArea();

                if (KeyDown(Key.Right) && player.Location[1] < Console.WindowWidth - 38)
                {
                    player.Location[1] += 1;
                    if (player.Animation != 2)
                        player.Animation = 1;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    player.PlayerDisplayed = false;
                }
                else if (KeyDown(Key.Right) && stage + 1 < map.Universe.Count())
                {
                    scene.LoadBackground(++stage);
                    scene.DisplayBackground();
                }
                else if (KeyDown(Key.Left) && player.Location[1] > 0)
                {
                    player.Location[1] -= 1;
                    player.Animation = 3;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    player.PlayerDisplayed = false;
                }
                else if (KeyDown(Key.Left) && stage > 0)
                {
                    scene.LoadBackground(--stage);
                    scene.DisplayBackground();
                }
                else if (!player.PlayerDisplayed)
                {
                    player.Animation = 0;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    player.PlayerDisplayed = true;
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
            //scene.LoadBackground(stage);
            Bitmap bmpSrc = new Bitmap(@"H:\Classes Spring 2018\CIT 195\Week 5\Class 2\TBQuestGame\TBQuestGFX\Rooms\Dungeon\dungeon2-2.png", true);
            scene.ConsoleWriteImage(bmpSrc,stage);
            scene.DisplayBackground();
            player.PrintObject(scene);
        }

        static bool KeyDown(Key pKey)
        {
            if (Keyboard.IsKeyDown(pKey))
                return true;
            return false;
        }

        void ManagePlayerInventory()
        {
            if (KeyDown(Key.Enter))
            {
                player.Inventory.Remove(scene._inventoryView[inventoryPos]);
                scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory", "");
            }
            if (KeyDown(Key.Up) && inventoryPos > 0)
                inventoryPos--;
            else if (KeyDown(Key.Down) && inventoryPos < scene._inventoryView.Count() - 1)
                inventoryPos++;

            scene.DisplayInventoryCursor(inventoryPos);

            Thread.Sleep(50);
            if (KeyDown(Key.I))
            {
                player.InventoryInit = false;
                player.PlayerDisplayed = false;
                scene.DisplayBackground();
            }
        }

        void SearchPlayerArea()
        {
            //for (int row = player.Location[0]; row < player.Height + player.Location[0] - 1; row++)
            //    for (int column = player.Location[1] + 4; column < player.Width + player.Location[1]; column++)
            //        if (scene._scene[column, row, 3] != '\0')
            //        {
            //            scene.DisplayText(2, 27, 10, 100, 8, 5, "\tITEM GET", "ITEM GOT!");
            //            return;
            //        }
            foreach (Object item in map.Universe[stage].Objects)
            {
                if (item.Location[0] <= player.Height + player.Location[0] && item.Location[0] + item.Height >= player.Location[0]
                   && item.Location[1] <= player.Width + player.Location[1] && item.Location[1] + item.Width >= player.Location[1] + 4)
                {
                    scene.DisplayText(2, 27, 10, 100, 8, 5, "ITEM GET", "You got " + ( item.Name != "" ? item.Name : "ITEM GOT" ) + "!");
                    player.Inventory.Add(item);
                    map.Universe[stage].Objects.Remove(item);
                    break;
                }
            }
        }
    }
}
