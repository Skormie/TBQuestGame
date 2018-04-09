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
        private int stage = 0;
        private int inventoryPos = 0;

        void ProgramLoop()
        {
            int count =  0;
            while (!Keyboard.IsKeyDown(Key.Escape))
            {
                count++;
                scene.ClearInputBuffer();
                Thread.Sleep(10);

                if (player.InventoryInit)
                {
                    ManagePlayerInventory();
                    continue;
                }

                if( KeyDown(Key.N) )
                {
                    scene.DisplayMenu(2, 50, 20, 50, 8, 5, "Test Menu", "Apple", "Grapes", "Strawberry", "Orange", "Fish");
                    scene.DisplayAreaLayer(2, 50, 20, 50);
                }

                if (count % 100 == 0)
                {
                    foreach (Object item in map.Universe[stage].Objects)
                        if (item.Sprite.Count > 1)
                            scene.DisplayAreaLayer(item.Location[0], item.Location[1] + 2, item.Height, item.Width, item.GetObjectFrame());
                    player.PlayerDisplayed = false;
                }

                if (KeyDown(Key.I))
                {
                    player.InventoryInit = true;
                    scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory");
                }

                if (KeyDown(Key.Space))
                {
                    scene.DisplayText(2, 27, 13, 100, 8, 5, "NPC NAME", "THIS IS SOME TEXT.");
                }

                if(KeyDown(Key.P))
                    SearchPlayerArea();

                if (KeyDown(Key.Right) && player.Location[1] < Console.WindowWidth - 25)
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
                    LoadStage(++stage);
                }
                else if (KeyDown(Key.Left) && player.Location[1] + 2 > 0)
                {
                    player.Location[1] -= 1;
                    player.Animation = 3;
                    player.PrintObject(scene);
                    scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
                    player.PlayerDisplayed = false;
                }
                else if (KeyDown(Key.Left) && stage > 0)
                {
                    LoadStage(--stage);
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
            map = new Map();
            player = new Player() {
                Name = "Hero",
                Level = 1,
                Location = new int[2] { 26, 10 },
                Width = 22,
                Height = 9,
                Health = 30,
                MaxHealth = 40,
                Inventory = new List<Object>()
            };
            scene = new ConsoleView(player, map);
            Console.CursorVisible = false;
            scene.SetupConsoleDisplay();
            scene.SplashScreen();
            LoadStage(stage);
        }

        public static bool KeyDown(Key pKey)
        {
            if (Keyboard.IsKeyDown(pKey))
                return true;
            return false;
        }

        public static bool KeyUp(Key pKey)
        {
            if (Keyboard.IsKeyUp(pKey))
                return true;
            return false;
        }

        public static bool KeyPressed(Key pKey)
        {
            if (Keyboard.IsKeyDown(pKey))
            {
                Thread.Sleep(100);
                if (Keyboard.IsKeyUp(pKey))
                    return true;
            }
            return false;
        }

        void ManagePlayerInventory()
        {
            if (KeyPressed(Key.Enter) && scene._inventoryView.Count() > 0)
            {
                Lootable item = (Lootable)scene._inventoryView[inventoryPos];
                switch (scene.DisplayMenu(2, 70, 20, 50, 8, 5, item.Name+" Options", "Use", "Look", "Drop", "Destroy"))
                {
                    case 0:
                        Potion potion = (Potion)scene._inventoryView[inventoryPos];
                        potion.Use(player, potion.heal);
                        scene.DisplayHealthBar();
                        player.Inventory.Remove(scene._inventoryView[inventoryPos]);
                        break;
                    case 1:
                        scene.DisplayText(2, 27, 13, 100, 8, 5, item.Name, item.Description);
                        break;
                    case 2:
                        item.Location[0] = player.Location[0] + player.Height - 5;
                        item.Location[1] = player.Location[1];
                        map.Universe[stage].Objects.Add(item);
                        player.Inventory.Remove(scene._inventoryView[inventoryPos]);
                        item.PrintObject(scene);
                        scene.DisplayObjectsScene(stage);
                        break;
                    case 3:
                        player.Inventory.Remove(scene._inventoryView[inventoryPos]);
                        break;
                    default:
                        break;
                }
                scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory");
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
                scene.DisplayAreaLayer(2, 27, 20, 50);
                Thread.Sleep(50);
            }
        }

        public void LoadStage(int stageSelect)
        {
            stage = stageSelect;
            scene.EraseLayers();
            scene.ConsoleWriteImage(stage);
            scene.DisplayBackground();
            scene.DisplayObjectsScene(stage);
            player.PrintObject(scene);
            scene.DisplayPlayerInfo();
            scene.DisplayHealthBar();
        }

        void SearchPlayerArea()
        {
            foreach (Object item in map.Universe[stage].Objects)
            {
                if (item.Location[0] <= player.Height + player.Location[0] && item.Location[0] + item.Height >= player.Location[0]
                   && item.Location[1] <= player.Width + player.Location[1] && item.Location[1] + item.Width >= player.Location[1] + 4)
                {
                    if (item is Lootable)
                    {
                        scene.DisplayText(2, 27, 10, 100, 8, 5, "ITEM GET", "You got " + (item.Name != "" ? item.Name : "ITEM GOT") + "!");
                        player.Inventory.Add(item);
                        scene.EraseObjectSceneLayer(stage, item);
                        scene.DisplayObjectSceneLayer(stage, item, ConsoleView.bkgLayer);
                        map.Universe[stage].Objects.Remove(item);
                        break;
                    }
                    if( item is Door )
                    {
                        Door door = item as Door;
                        door.Open(player, this, scene);
                        break;
                    }
                }
            }
        }
    }
}
