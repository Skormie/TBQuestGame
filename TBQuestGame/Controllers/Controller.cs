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
    public class Controller
    {
        public Player player;
        public ConsoleView scene;
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

                KeyControls();

                if (count % 100 == 0)
                {
                    foreach (Object item in Area.maps[player.Stage][player.StageDepth].Objects)
                        if (item.Sprite.Count > 1)
                            scene.DisplayAreaLayer(item.Location[0], item.Location[1] + 2, item.Height, item.Width, item.GetObjectFrame());
                    player.PlayerDisplayed = false;
                }
            }
        }

        public Controller()
        {
            InitializeGame();
            ProgramLoop();
        }

        // Instantiating Key Game Elements.
        private void InitializeGame()
        {
            //world = new Area();
            player = new Player() {
                Name = "Hero",
                Color = ConsoleColor.White,
                Level = 1,
                Location = new int[2] { 26, 10 },
                Width = 22,
                Height = 9,
                Health = 30,
                MaxHealth = 40,
                Inventory = new List<Object>()
            };
            scene = new ConsoleView(player);
            Console.CursorVisible = false;
            scene.SetupConsoleDisplay();
            scene.SplashScreen();
            LoadStage(Universe.playerstart);
            //LoadStage(player.Stage);
        }

        // Methods used to control the character with keyboard keys.
        #region Control Character With Keys
        void KeyControls()
        {
            if (KeyDown(Key.N))
            {
                scene.DisplayMenu(2, 50, 20, 50, 8, 5, "Test Menu", "Apple", "Grapes", "Strawberry", "Orange", "Fish");
                scene.DisplayAreaLayer(2, 50, 20, 50);
            }

            if (KeyPressed(Key.I))
            {
                player.InventoryInit = true;
                scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory");
            }

            if (KeyDown(Key.P))
                SearchPlayerArea();

            if (KeyPressed(Key.M))
                LoadMap();

            if (KeyDown(Key.Right) && player.Location[1] < scene._scene.GetLength(0) - 25)
            {
                player.Location[1] += 1;
                if (player.Animation != 2)
                    player.Animation = 1;
                UpdatePlayerDisplay();
                player.PlayerDisplayed = false;
            }
            else if (KeyDown(Key.Right) && player.StageDepth + 1 < Area.maps[player.Stage].Count()) //See if the player is running into the right wall and if it's the last stage in that Area.
            {
                player.Location[1] = -2;
                LoadStage(++player.StageDepth);
            }
            else if (KeyDown(Key.Right) && player.StageDepth + 1 == Area.maps[player.Stage].Count()) //If it's the last map in that area we're going to load the next area.
            {
                if(player.Stage + 1 < Area.maps.Length)
                {
                    player.Location[1] = -2;
                    player.StageDepth = 0;
                    player.Stage++;
                    LoadStage(player.StageDepth);
                }
            }
            else if (KeyDown(Key.Left) && player.Location[1] + 2 > 0)
            {
                player.Location[1] -= 1;
                player.Animation = 3;
                UpdatePlayerDisplay();
                player.PlayerDisplayed = false;
            }
            else if (KeyDown(Key.Left) && player.StageDepth > 0)
            {
                player.Location[1] = scene._scene.GetLength(0) - 25;
                LoadStage(--player.StageDepth);
            }
            else if (KeyDown(Key.Left) && player.Stage > 0) //If it's the last map in that area we're going to load the next area.
            {
                if (player.Stage > 0)
                {
                    player.Location[1] = scene._scene.GetLength(0) - 25;
                    player.Stage--;
                    player.StageDepth = Area.maps[player.Stage].Count() -1;
                    LoadStage(player.StageDepth);
                }
            }
            else if (!player.PlayerDisplayed)
            {
                player.Animation = 0;
                UpdatePlayerDisplay();
                player.PlayerDisplayed = true;
            }
        }
        #endregion

        // Methods Regarding Player Key Inputs.
        #region KeyMethods
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
        #endregion

        // Allows the player to navigate thier inventory.
        void ManagePlayerInventory()
        {
            if (KeyPressed(Key.Enter))
            {
                if (scene._inventoryView.Count() > 0)
                {
                    Lootable item = (Lootable)scene._inventoryView[inventoryPos];
                    switch (scene.DisplayMenu(2, 70, 20, 50, 8, 5, item.Name + " Options", "Use", "Look", "Drop", "Destroy"))
                    {
                        case 0:
                            item.Use(this, item.EffectInts);
                            break;

                        case 1:
                            scene.DisplayText(item.Name, item.Description);
                            break;

                        case 2:
                            if (item.CanDrop)
                                DropItem(item);
                            else
                                scene.DisplayText(item.Name, "Cannot be dropped!");
                            break;

                        case 3:
                            if (item.CanDestroy)
                                RemoveInventoryItem();
                            else
                                scene.DisplayText(item.Name, "Cannot be destroyed!");
                            break;

                        default:
                            break;
                    }
                    scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory");
                }
                else
                    CloseInventory();
            }

            if (KeyPressed(Key.Up) && inventoryPos > 0)
                inventoryPos--;
            else if (KeyPressed(Key.Down) && inventoryPos < scene._inventoryView.Count() - 1)
                inventoryPos++;

            scene.DisplayInventoryCursor(inventoryPos);

            if (KeyPressed(Key.I))
                CloseInventory();
        }

        // Prints and redraws the player to the screen.
        public void UpdatePlayerDisplay()
        {
            player.PrintObject(scene);
            scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
        }

        // This method removes an items from the inventory and resets the cursor.
        public void RemoveInventoryItem()
        {
            player.Inventory.Remove(scene._inventoryView[inventoryPos]);
            if (inventoryPos > 0)
                inventoryPos--;
            scene.DisplayInventoryCursor(inventoryPos);
        }

        // This method calls other methods to load the stage.
        public void LoadStage(int stageSelect)
        {
            player.StageDepth = stageSelect;
            scene.EraseLayers();
            scene.ConsoleWriteImage();
            scene.DisplayBackground();
            scene.DisplayObjectsScene();
            player.PrintObject(scene);
            player.PlayerDisplayed = false;
            scene.DisplayPlayerInfo();
            scene.DisplayHealthBar();
        }

        public void LoadStage( Stage Map )
        {
            //player.Stage = stageSelect;
            scene.EraseLayers();
            scene.ConsoleWriteImage(Map);
            scene.DisplayBackground();
            scene.DisplayObjectsScene();
            player.PrintObject(scene);
            player.PlayerDisplayed = false;
            scene.DisplayPlayerInfo();
            scene.DisplayHealthBar();
        }

        public void LoadMap()
        {
            scene.EraseLayers();
            scene.ConsoleWriteImage(Universe.map);
            scene.DisplayBackground();
            Console.ReadLine();
            LoadStage(player.StageDepth);
        }

        // This is the prefered way to remove items from the scene.
        public void RemoveStageItem(Object item)
        {
            scene.EraseObjectSceneLayer(item);
            scene.DisplayObjectSceneLayer(item, ConsoleView.bkgLayer);
            Area.maps[player.Stage][player.StageDepth].Objects.Remove(item);
            foreach (var obj in Area.maps[player.Stage][player.StageDepth].Objects)
                if (obj is Lootable)
                {
                    obj.PrintObject(scene);
                    scene.DisplayObjectSceneLayer(obj, obj.Layer);
                }
        }

        public void PickupItem(Object item)
        {
            scene.DisplayText("ITEM GET:", "You got " + item.Name + "!");
            player.Experience += item.Experience;
            item.Experience = 0;
            UpdatePlayerLevel();
            player.Inventory.Add(item);
            RemoveStageItem(item);
        }

        public void UpdatePlayerLevel()
        {
            if(player.Experience >= player.NextExperience)
            {
                player.Level++;
                player.Experience = 0;
                player.NextExperience *= 2;
            }
            scene.DisplayPlayerInfo();
        }

        public void DropItem(Object item)
        {
            item.Location[0] = player.Location[0] + player.Height - item.Height;
            item.Location[1] = player.Location[1];
            Area.maps[player.Stage][player.StageDepth].Objects.Add(item);
            RemoveInventoryItem();
            item.PrintObject(scene);
            scene.DisplayObjectsScene();
        }

        public void CloseInventory()
        {
            player.InventoryInit = false;
            player.PlayerDisplayed = false;
            scene.DisplayAreaLayer(2, 27, 20, 50);
        }

        // Fliters through every item in the current stage. If they are within reach sorts them into list by priority.
        void SearchPlayerArea()
        {
            List<Lootable> lootList = new List<Lootable>();
            List<Door> doorList = new List<Door>();
            List<NPC> npcList = new List<NPC>();
            foreach (Object item in Area.maps[player.Stage][player.StageDepth].Objects)
            {
                if (item.Location[0] <= player.Height + player.Location[0] && item.Location[0] + item.Height >= player.Location[0]
                   && item.Location[1] <= player.Width + player.Location[1] && item.Location[1] + item.Width >= player.Location[1] + 4)
                    if (item is Lootable)
                        lootList.Add(item as Lootable);
                    else if (item is Door)
                        doorList.Add(item as Door);
                    else if (item is NPC)
                        npcList.Add(item as NPC);
            }
            if (lootList.Count() > 0)
                PickupItem(lootList[0]);
            else if (npcList.Count() > 0)
            {
                scene.DisplayText(npcList[0].Name, npcList[0].Dialogue);
            }
            else if (doorList.Count() > 0)
                doorList[0].Open(player, this, scene);
        }
    }
}
