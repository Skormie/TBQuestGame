using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public static class Universe
    {
        static List<Object> Empty = new List<Object>();


        #region Player Start
        public static Stage playerstart = new Stage(@"\TBQuestGFX\Rooms\Dungeon\player_start.png", new List<Object>());
        #endregion

        #region Field Stages
        private static List<Object> fieldObjects = new List<Object>()
        {
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 121 } },
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 25 } },
            new Misc(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "Shiny Thing" },
            new Misc(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "Shiny Thing2" }
        };
        public static Stage field = new Stage(@"\TBQuestGFX\Rooms\Field\field1.png", fieldObjects);
        public static Stage emptyField = new Stage(@"\TBQuestGFX\Rooms\Field\field1.png", new List<Object>());
        public static Stage fieldForest = new Stage(@"\TBQuestGFX\Rooms\Field\field2.png", new List<Object>());
        #endregion

        #region First Town Stages
        public static Stage townTown = new Stage(@"\TBQuestGFX\Rooms\Towns\town1day.png", new List<Object>());
        public static Stage townTavern = new Stage(@"\TBQuestGFX\Rooms\Towns\tavernday.png", new List<Object>());
        public static Stage townItemAndForge = new Stage(@"\TBQuestGFX\Rooms\Towns\itemandforgeday.png", new List<Object>());
        public static Stage townCastle = new Stage(@"\TBQuestGFX\Rooms\Towns\castle.png", new List<Object>());
        #endregion

        #region Forest Stages
        public static Stage forestStraight = new Stage(@"\TBQuestGFX\Rooms\Forest\straightForest.png", new List<Object>());
        public static Stage forestDead = new Stage(@"\TBQuestGFX\Rooms\Forest\deadWoods.png", new List<Object>());
        public static Stage forestThickDead = new Stage(@"\TBQuestGFX\Rooms\Forest\thickDeadWoods.png", new List<Object>());
        public static Stage forestStraightField = new Stage(@"\TBQuestGFX\Rooms\Forest\straightForestField.png", new List<Object>());
        #endregion

        #region Light Dungeon Stage
        static Misc lightdunKey = new Misc(Sprites.sprite["key"]) {
            Location = new int[2] { 25, 100 },
            Name = "Light Dungeon Key",
            Color = ConsoleColor.Yellow
        };

        private static List<Object> lightDungeonObjects = new List<Object>()
        {
            //Background Objects
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 100 } },
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 25 } },

            //Usable/Misc Objects
            new Misc(Sprites.sprite["potion3"]) { Location = new int[2]{ 25, 25 }, Name = "Empty Bottle", Color = ConsoleColor.White },
            new Potion(Sprites.sprite["potion1"]) {
                Location = new int[2]{ 25, 130 },
                Name = "Experience Bottle",
                EffectInts = new int[1] { 50 },
                Use = new ItemMethod(Delegates.AddExperience),
                Description = "This bottle grants you 50 experience points!",
                Color = ConsoleColor.Green
            },
            new Potion(Sprites.sprite["potion1"]) {
                Location = new int[2]{ 25, 50 },
                Name = "Life Elixer",
                EffectInts = new int[1] { 50 },
                Use = new ItemMethod(Delegates.AddMaxHP),
                Description = "This potion will increase your max HP by 50.",
                Color = ConsoleColor.DarkRed
            },
            new Potion(Sprites.sprite["potion2"]) {
                Location = new int[2]{ 25, 70 },
                Name = "Healing Potion",
                EffectInts = new int[1] { 50 },
                Use = new ItemMethod(Delegates.AddHP),
                Description = "This potion will increase your HP by 50.",
                Color = ConsoleColor.Red
            },

            //Doors
            new Door(Sprites.sprite["door"]) {
                Location = new int[2]{ 14, 140 },
                Name = "Door",
                WarpMap = 0,
                WarpX = 10,
                WarpY = 26,
                DoorKey = lightdunKey,
                IsLocked = true
            },

            new NPC(Sprites.sprite["woman"])
            {
                Location = new int[2]{ 25, 145 },
                Color = ConsoleColor.White,
                Name = "Anna",
                Dialogue = "Lovely weather we're having!",
                Layer = 1
            },

            lightdunKey
        };

        public static Stage lightDungeon = new Stage( @"\TBQuestGFX\Rooms\Dungeon\room1.png", lightDungeonObjects);
        #endregion

        public static Stage shop = new Stage(@"\TBQuestGFX\Rooms\Towns\innershop.png", new List<Object>());

        public static Stage ditherDungeon = new Stage(@"\TBQuestGFX\Rooms\Dungeon\dungeon2-2.png", new List<Object>());

        public static Stage map = new Stage(@"\TBQuestGFX\map.png", new List<Object>());

    }
}
