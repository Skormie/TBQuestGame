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
        public const int floor = 26;

        public Player player;
        public ConsoleView scene;
        public Enemy opponent;
        private int inventoryPos = 0;

        public static System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();

        void ProgramLoop()
        {
            int count =  0;
            while (!Keyboard.IsKeyDown(Key.Escape))
            {
                count++;
                scene.ClearInputBuffer();
                Thread.Sleep(7);

                if (player.InventoryInit)
                {
                    ManagePlayerInventory();
                    continue;
                }

                if (player.battleInit)
                {
                    Random rng = new Random();
                    scene.DisplayHealthBar(1, 1);
                    scene.DisplayEnemyHealthBar(opponent.Health, opponent.MaxHealth);
                    if (player.Turn)
                    {
                        int input = scene.DisplayMenu(2, 50, 20, 50, 8, 5, "Attack Menu", "Attack", "Defend", "Items", "Run");
                        switch (input)
                        {
                            case 0:
                                player.Damage = rng.Next(rng.Next(player.Attack), player.Attack) + 10;
                                scene.DisplayText("Battle Text", "You attack " + opponent.Name + " for " + player.Damage + " damage!", 36, 0, 8, 192, 8, 5);
                                opponent.Damage = rng.Next(rng.Next(opponent.Attack), opponent.Attack);
                                opponent.Health -= player.Damage;
                                break;
                            case 1:
                                scene.DisplayText("Battle Text", "You defend!", 36, 0, 8, 192, 8, 5);
                                opponent.Damage = rng.Next(rng.Next(opponent.Attack), opponent.Attack) / 2;
                                break;
                            case 2:
                                player.InventoryInit = true;
                                opponent.Damage = rng.Next(rng.Next(opponent.Attack), opponent.Attack);
                                scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory");
                                break;
                            case 3:
                                player.battleInit = false;
                                scene.DisplayText("Battle Text", "You got away!", 36, 0, 8, 192, 8, 5);
                                break;
                            default:
                                break;
                        }
                        if(!player.InventoryInit)
                            scene.DisplayAreaLayer(2, 50, 20, 50);
                        player.Turn = false;
                    }
                    else
                    {
                        scene.DisplayText("Battle Text", opponent.Name + " attacked you for " + opponent.Damage + " damage!", 36, 0, 8, 192, 8, 5);
                        player.Health -= opponent.Damage;
                        player.Turn = true;
                    }
                    if (!player.battleInit || opponent.Health <= 0 || player.Health <= 0)
                    {
                        scene.DisplayHealthBar(1, 1);
                        scene.DisplayEnemyHealthBar(opponent.Health, opponent.MaxHealth);
                        if (opponent.Health <= 0)
                        {
                            player.Experience += opponent.Experience;
                            UpdatePlayerLevel();
                            scene.DisplayText("Battle Text", " Hey you won! You've earned " + opponent.Experience + " experience!", 36, 0, 8, 192, 8, 5);
                        }
                        player.Turn = true;
                        player.battleInit = false;
                        player.Location[1] = player.BattleMapXYZ[1];
                        player.Location[0] = player.BattleMapXYZ[2];
                        LoadStage();
                    }
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
                Inventory = new List<Object>(),
                Stage = 6,
                StageDepth = 0
            };
            scene = new ConsoleView(player);
            Console.CursorVisible = false;
            scene.SetupConsoleDisplay();
            scene.SplashScreen();
            //LoadStage(Universe.playerstart);
            LoadStage();
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

            Traveling();
        }

        void Traveling()
        {
            if (KeyDown(Key.Right))
            {
                if (player.Location[1] < scene._scene.GetLength(0) - 25)
                {
                    player.Location[1] += 1;
                    if (player.Animation != 2)
                        player.Animation = 1;
                    UpdatePlayerDisplay();
                    player.PlayerDisplayed = false;
                }
                else if (player.StageDepth + 1 < Area.maps[player.Stage].Count()) //See if the player is running into the right wall and if it's the last stage in that Area.
                {
                    player.Location[1] = -2;
                    player.StageDepth++;
                    LoadStage();
                }
                else if (Area.maps[player.Stage][player.StageDepth].MapWarpRight != null)
                {
                    Warp MapWarpRight = Area.maps[player.Stage][player.StageDepth].MapWarpRight;
                    LoadStageUpdateLoc(GetMapIndex(MapWarpRight.Map), MapWarpRight.X, MapWarpRight.Y, MapWarpRight.Z);
                }
                else if (player.Stage + 1 < Area.maps.Length) //If it's the last map in that area we're going to load the next area.
                {
                    if (Area.maps[player.Stage + 1].Count() > 0)
                    {
                        player.Location[1] = -2;
                        player.StageDepth = 0;
                        player.Stage++;
                        LoadStage();
                    }
                    else if (Area.maps[player.Stage][player.StageDepth].Indoors && player.LastMapXYZ.Length > 0)
                    {
                        LoadStageUpdateLoc(player.LastMapXYZ);
                    }
                }
            }
            else if (KeyDown(Key.Left))
            {
                if (player.Location[1] + 2 > 0)
                {
                    player.Location[1] -= 1;
                    if (player.Animation != 6)
                        player.Animation = 5;
                    UpdatePlayerDisplay();
                    player.PlayerDisplayed = false;
                }
                else if (player.StageDepth > 0)
                {
                    player.Location[1] = scene._scene.GetLength(0) - 25;
                    player.StageDepth--;
                    LoadStage();
                }
                else if (Area.maps[player.Stage][player.StageDepth].MapWarpLeft != null)
                {
                    Warp MapWarpLeft = Area.maps[player.Stage][player.StageDepth].MapWarpLeft;
                    LoadStageUpdateLoc(GetMapIndex(MapWarpLeft.Map), MapWarpLeft.X, MapWarpLeft.Y, MapWarpLeft.Z);
                }
                else if ( player.Stage > 0 ) //If it's the last map in that area we're going to load the next area.
                {
                    if (Area.maps[player.Stage - 1].Count() > 0)
                    {
                        player.Location[1] = scene._scene.GetLength(0) - 25;
                        player.Stage--;
                        player.StageDepth = Area.maps[player.Stage].Count() - 1;
                        LoadStage();
                    }
                    else if (Area.maps[player.Stage][player.StageDepth].Indoors && player.LastMapXYZ.Length > 0)
                    {
                        LoadStageUpdateLoc(player.LastMapXYZ);
                    }
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
            //while (!KeyUp(Key.Enter)) { }
            if (KeyPressed(Key.Enter))
            {
                soundPlayer.SoundLocation = @System.IO.Directory.GetCurrentDirectory() + @"\TBQuestMusic\Menu Sounds\menu_cancel.wav";
                soundPlayer.Play();
                if (scene._inventoryView.Count() > 0)
                {
                    Lootable item = (Lootable)scene._inventoryView[inventoryPos];
                    switch (scene.DisplayMenu(2, 70, 20, 50, 8, 5, item.Name + " Options", "Use", "Look", "Drop", "Destroy"))
                    {
                        case 0:
                            item.Use(this, item.EffectStrings);
                            break;

                        case 1:
                            scene.DisplayText(item.Name, item.Description);
                            break;

                        case 2:
                            if (item.CanDrop && !player.battleInit)
                                DropItem(item);
                            else
                                scene.DisplayText(item.Name, "Cannot be dropped!");
                            break;

                        case 3:
                            if (item.CanDestroy && !player.battleInit)
                                RemoveInventoryItem();
                            else
                                scene.DisplayText(item.Name, "Cannot be destroyed!");
                            break;

                        default:
                            soundPlayer.SoundLocation = @System.IO.Directory.GetCurrentDirectory() + @"\TBQuestMusic\Menu Sounds\menu_cancel2.wav";
                            soundPlayer.Play();
                            break;
                    }
                    scene.DisplayInventory(2, 27, 20, 50, 8, 5, "Inventory");
                }
                else
                    CloseInventory();
            }

            if (KeyPressed(Key.Up) && inventoryPos > 0)
            {
                inventoryPos--;
                soundPlayer.SoundLocation = @System.IO.Directory.GetCurrentDirectory() + @"\TBQuestMusic\Menu Sounds\menuupdown.wav";
                soundPlayer.Play();
            }
            else if (KeyPressed(Key.Down) && inventoryPos < scene._inventoryView.Count() - 1)
            {
                inventoryPos++;
                soundPlayer.SoundLocation = @System.IO.Directory.GetCurrentDirectory() + @"\TBQuestMusic\Menu Sounds\menuupdown.wav";
                soundPlayer.Play();
            }

            scene.DisplayInventoryCursor(inventoryPos);

            if (KeyPressed(Key.I))
            {
                soundPlayer.SoundLocation = @System.IO.Directory.GetCurrentDirectory() + @"\TBQuestMusic\Menu Sounds\menu_confirm.wav";
                soundPlayer.Play();
                CloseInventory();
            }
        }

        public int GetMapIndex(string searchMap)
        {
            for (int i = 0; i < Area.maps.Length; i++)
                if (Area.mapLookup[searchMap] == Area.maps[i])
                    return i;
            return -1;
        }

        // Prints and redraws the player to the screen.
        public void UpdatePlayerDisplay()
        {
            player.PrintObject(scene);
            scene.DisplayArea(player.Location[0] - 1, player.Location[1] + 3, player.Height, player.Width);
            if (Area.maps[player.Stage][player.StageDepth].Spawns.Count > 0 && !player.battleInit)
            {
                int chance = 0;
                foreach (var mobSpawn in Area.maps[player.Stage][player.StageDepth].Spawns)
                    chance += mobSpawn._chance;

                int i = 0;
                Random rng = new Random();
                int rand = rng.Next(0, chance);
                while ((rand -= Area.maps[player.Stage][player.StageDepth].Spawns[i]._chance) >= 0) i++;

                if (Area.maps[player.Stage][player.StageDepth].Spawns[i]._mob != null)
                {
                    //Console.Clear();
                    //Console.WriteLine(Area.maps[player.Stage][player.StageDepth].Spawns[i]._mob.Name);
                    //Console.ReadLine();
                    Area.maps[player.Stage][player.StageDepth].Spawns[i]._mob.PrintObject(scene);
                    opponent = new Enemy(Area.maps[player.Stage][player.StageDepth].Spawns[i]._mob);
                    scene.DisplayObjectSceneLayer(opponent, opponent.Layer);
                    player.battleInit = true;
                    player.BattleMapXYZ[0] = player.Stage;
                    player.BattleMapXYZ[1] = player.Location[1];
                    player.BattleMapXYZ[2] = player.Location[0];
                    player.BattleMapXYZ[3] = player.StageDepth;
                    scene.DisplayObjectSceneLayer(player, ConsoleView.bkgLayer, false);
                    //player.Location[1] = player.BattleMapXYZ[1];
                    //player.Location[0] = player.BattleMapXYZ[2];
                    player.Location[1] = 10;
                    player.Location[0] = floor;
                    player.Animation = 0;
                    UpdatePlayerDisplay();
                    scene.DisplayText("Battle Text", "You've encountered " + opponent.Name + "!", 36, 0, 8, 192, 8, 5);
                    scene.DisplayPlayerInfo(1, 0);
                    scene.DisplayEnemyInfo(opponent.Level, opponent.Name);
                    //player.Stage = player.BattleMapXYZ[0];
                    //player.StageDepth = player.BattleMapXYZ[3];
                    //control.LoadStage();
                }
            }
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
        public void LoadStage()
        {
            NAudio.PlayFile(Area.maps[player.Stage][player.StageDepth].Music);

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

        public void LoadStageUpdateLoc(int stage, int x, int y, int z)
        {
            player.Stage = stage;
            player.Location[1] = x;
            player.Location[0] = y;
            player.StageDepth = z;
            LoadStage();
        }

        public void LoadStageUpdateLoc(int[] stage)
        {
            player.Stage = stage[0];
            player.Location[1] = stage[1];
            player.Location[0] = stage[2];
            player.StageDepth = stage[3];
            LoadStage();
        }

        public void LoadMap()
        {
            scene.EraseLayers();
            scene.ConsoleWriteImage(Universe.map);
            scene.DisplayBackground();
            Console.ReadLine();
            LoadStage();
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
            scene.DisplayText("Item Get", item.Name + " was added to your inventory!");
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

        private void HandleObjectAddedToInventory(object gameObject, EventArgs e)
        {
            if(gameObject.GetType() == typeof(Object))
            {
                Object obj = gameObject as Object;
                scene.DisplayText("Item Get", obj.Name + " was added to your inventory!");
            }
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
                if(npcList[0] is ISpeak)
                {
                    player.Experience += npcList[0].Experience;
                    npcList[0].Experience = 0;
                    UpdatePlayerLevel();
                    ISpeak speak = npcList[0] as ISpeak;
                    scene.DisplayText(npcList[0].Name, speak.Speak());
                }
                else
                    scene.DisplayText(npcList[0].Name, npcList[0].Dialogue);
            }
            else if (doorList.Count() > 0)
                doorList[0].Open(player, this);
        }
    }
}
