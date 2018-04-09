using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public static class Stages
    {

        #region Field Stage
        private static List<Object> fieldObjects = new List<Object>()
        {
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 121 } },
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 25 } },
            new Misc(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "Shiny Thing", Layer = 1 },
            new Misc(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "Shiny Thing2", Layer = 1 }
        };
        public static Stage field = new Stage(@"\TBQuestGFX\Rooms\Field\field1.png", fieldObjects);
        #endregion

        #region Light Dungeon Stage
        static Misc lightdunKey = new Misc(Sprites.sprite["key"]) { Location = new int[2] { 25, 100 }, Name = "Light Dungeon Key", Layer = 1 };
        private static List<Object> lightDungeonObjects = new List<Object>()
        {
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 121 }, Layer = 1 },
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 25 } },
            new Misc(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "Shiny Thing", Layer = 1 },
            //new Object(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "No Loot!", Layer = 1 },
            new Potion(Sprites.sprite["potion1"]) { Location = new int[2]{ 25, 50 }, Name = "Life Elixer", heal = 50, Use = new ItemMethod(Delegates.AddMaxHP), Description = "This potion will increase your max HP by 50.", Layer = 1 },
            new Potion(Sprites.sprite["potion2"]) { Location = new int[2]{ 25, 70 }, Name = "Healing Potion", heal = 50, Use = new ItemMethod(Delegates.AddHP), Description = "This potion will increase your max HP by 50.", Layer = 1 },
            new Door(Sprites.sprite["door"]) { Location = new int[2]{ 15, 120 }, Name = "Door", WarpMap = 0, WarpX = 10, WarpY = 26, DoorKey = lightdunKey, IsLocked = true },
            lightdunKey
        };
        public static Stage lightDungeon = new Stage( @"\TBQuestGFX\Rooms\Dungeon\room1.png", lightDungeonObjects);
        #endregion

        public static Stage shop = new Stage(@"\TBQuestGFX\Rooms\Towns\innershop.png", new List<Object>());

        public static Stage ditherDungeon = new Stage(@"\TBQuestGFX\Rooms\Dungeon\dungeon2-2.png", new List<Object>());

    }
}
