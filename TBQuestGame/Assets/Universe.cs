using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public static class Universe
    {
        //Mob Spawns
        public static List<MobSpawn> starterMobs = new List<MobSpawn>()
        {
            new MobSpawn( Monsters.slime, 10 ),
            new MobSpawn( Monsters.slimeblue, 10 ),
            new MobSpawn( Monsters.goblin, 1 ),
            new MobSpawn( Monsters.goblinGreen, 1 ),
            new MobSpawn( null, 10000 )
        };

        public static List<MobSpawn> fieldMobs = new List<MobSpawn>()
        {
            new MobSpawn( Monsters.slime, 10 ),
            new MobSpawn( Monsters.goblin, 1 ),
            new MobSpawn( null, 7000 )
        };

        public static List<MobSpawn> plainsMobs = new List<MobSpawn>()
        {
            new MobSpawn( Monsters.bandit, 10 ),
            new MobSpawn( Monsters.spider, 1 ),
            new MobSpawn( null, 5000 )
        };

        public static List<MobSpawn> deadWoodsMobs = new List<MobSpawn>()
        {
            new MobSpawn( Monsters.ghost, 10 ),
            new MobSpawn( Monsters.skeleton, 1 ),
            new MobSpawn( Monsters.skeleton2, 1 ),
            new MobSpawn( null, 5000 )
        };


        static List<Object> Empty = new List<Object>();

        public static Stage shop = new Stage(@"\TBQuestGFX\Rooms\Towns\innershop.png", new List<Object>()) { Indoors = true };
        public static Stage innerCastle = new Stage(@"\TBQuestGFX\Rooms\Towns\innercastle.png", new List<Object>()) { Indoors = true };
        public static Stage innerHouse = new Stage(@"\TBQuestGFX\Rooms\Towns\innerhouse.png", new List<Object>()) { Indoors = true };
        public static Stage innerHouse2 = new Stage(@"\TBQuestGFX\Rooms\Towns\innerhouse2.png", new List<Object>()) { Indoors = true };

        #region Player Start
        public static Stage playerstart = new Stage(@"\TBQuestGFX\Rooms\Dungeon\player_start.png", new List<Object>());
        #endregion

        #region Field Stages
        private static List<Object> fieldObjects = new List<Object>()
        {
            new Misc(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "Shiny Thing" },
            new Misc(Sprites.sprite["shinyThing"]) { Location = new int[2]{ 25, 25 }, Name = "Shiny Thing2" }
        };
        public static Stage field = new Stage(@"\TBQuestGFX\Rooms\Field\field1day.png", fieldObjects) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        public static Stage fieldFence = new Stage(@"\TBQuestGFX\Rooms\Field\field5day.png", new List<Object>()) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        public static Stage fencedField = new Stage(@"\TBQuestGFX\Rooms\Field\field3day.png", new List<Object>()) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        public static Stage fenceField = new Stage(@"\TBQuestGFX\Rooms\Field\field4day.png", new List<Object>()) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        public static Stage emptyField = new Stage(@"\TBQuestGFX\Rooms\Field\field1day.png", new List<Object>()) { Spawns = starterMobs, Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        public static Stage fieldForest = new Stage(@"\TBQuestGFX\Rooms\Field\field2day.png", new List<Object>()) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        public static Stage reverseField = new Stage(@"\TBQuestGFX\Rooms\Field\field7day.png", new List<Object>()) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        #endregion

        #region First Town Stages
        private static List<Object> townObjects = new List<Object>()
        {
            //Usable/Misc Objects
            new Potion(Sprites.sprite["potion1"]) {
                Location = new int[2]{ 25, 50 },
                Name = "Small Life Potion",
                EffectStrings = new string[1] { "10" },
                Use = new ItemMethod(Delegates.AddHP),
                Description = "This potion will increase your max HP by 10.",
                Color = ConsoleColor.DarkCyan
            },

            new Misc(Sprites.sprite["infoBox"]) {
                Location = new int[2]{ 25, 20 },
                Name = "Flyer",
                EffectStrings = new string[2] { "Flyer", "Trust your king. Live by your king and you will prosper." },
                Use = new ItemMethod(Delegates.DisplayText),
                Description = "There's something written on the back: The king is a madman he can't be trusted!!!.",
                Color = ConsoleColor.DarkMagenta
            },

            new Civilian(Sprites.sprite["man"])
            {
                Location = new int[2]{ 25, 145 },
                Color = ConsoleColor.DarkGray,
                Experience = 100,
                Name = "Weird Man",
                Dialogue = new List<string>() { "Look I don't have time for this!", "Go away!", "Stop talking to me!" },
                Layer = 1
            }
        };

        public static Stage townTown = new Stage(@"\TBQuestGFX\Rooms\Towns\town1day.png", townObjects) { Music = @"\TBQuestMusic\First Town\Forest Village.mp3" };
        public static Stage townTavern = new Stage(@"\TBQuestGFX\Rooms\Towns\tavernday.png", new List<Object>()) { Music = @"\TBQuestMusic\First Town\Forest Village.mp3" };
        public static Stage townItemAndForge = new Stage(@"\TBQuestGFX\Rooms\Towns\itemandforgeday.png", new List<Object>()) { Music = @"\TBQuestMusic\First Town\Forest Village.mp3" };
        #endregion

        #region Forest Stages
        private static List<Object> forestStraightObjects = new List<Object>()
        {
            new Potion(Sprites.sprite["potion3"]) {
                Location = new int[2]{ 27, 50 },
                Name = "Speedy Speed Boi",
                EffectStrings = new string[1] { "4" },
                Use = new ItemMethod(Delegates.AddSpeed),
                Description = "This potion will increase your speed.",
                Color = ConsoleColor.Magenta
            },

            //Doors
            new Door( Sprites.sprite["forestDoor"] ) {
                Location = new int[2]{ 0, 74 },
                Name = "Shop Enterance",
                WarpMap = "Albert's Shop",
                WarpX = 4,
                WarpY = Controller.floor
            }
        };
        public static Stage forestStraight = new Stage(@"\TBQuestGFX\Rooms\Forest\straightForest.png", forestStraightObjects) { Music = @"\TBQuestMusic\Sacred Forest\aquaticas_1.mp3" };
        public static Stage forestStraightField = new Stage(@"\TBQuestGFX\Rooms\Forest\forestField.png", new List<Object>()) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        #endregion

        #region Cave
        private static List<Object> caveExitObjects = new List<Object>()
        {
            //Doors
            new Door(Sprites.sprite["empty"], 16, 14 * 2) {
                Location = new int[2]{ 16, 8 },
                Name = "Cave Enterance",
                WarpMap = "Mountain Pass",
                WarpX = 192 - 25,
                WarpY = Controller.floor,
                WarpZ = 7
            }
        };

        private static List<Object> caveEnteranceObjects = new List<Object>()
        {
            //Doors
            new Door( Sprites.sprite["empty"], 16, 14 * 2 ) {
                Location = new int[2]{ 16, 78 * 2 },
                Name = "Cave Enterance",
                WarpMap = "Mountain Pass",
                WarpX = 4,
                WarpY = Controller.floor
            }
        };

        private static List<Object> caveLightEnterObjects = new List<Object>()
        {
            //Doors
            new Door( Sprites.sprite["caveDoor"] ) {
                Location = new int[2]{ 12, 78 },
                Name = "Shop Enterance",
                WarpMap = "Albert's Shop",
                WarpX = 4,
                WarpY = Controller.floor
            }
        };
        public static Stage caveLightEnter = new Stage(@"\TBQuestGFX\Rooms\Cave\cave1.png", caveLightEnterObjects)
        {
            MapWarpLeft = new Warp()
            {
                Map = "Taltree",
                X = ConsoleView._windowWidth -25,
                Y = Controller.floor,
                Z = 4
            },
            Music = @"\TBQuestMusic\Cave\Night Cave.mp3"
        };

        public static Stage caveLightExit = new Stage(@"\TBQuestGFX\Rooms\Cave\cave1.png", new List<Object>())
        {
            MapWarpRight = new Warp()
            {
                Map = "Plains",
                X = 0,
                Y = Controller.floor,
                Z = 0
            },
            Music = @"\TBQuestMusic\Cave\Night Cave.mp3"
        };

        public static Stage caveLight = new Stage(@"\TBQuestGFX\Rooms\Cave\cave1.png", new List<Object>()) { Music = @"\TBQuestMusic\Cave\Night Cave.mp3" }
        ;
        private static List<Object> caveDarkObjects = new List<Object>()
        {
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 142 } },
            new Object(Sprites.sprite["torch"]) { Location = new int[2]{ 10, 30 } }
        };
        public static Stage caveDark = new Stage(@"\TBQuestGFX\Rooms\Cave\cave2.png", caveDarkObjects) { Music = @"\TBQuestMusic\Cave\Night Cave.mp3" };
        public static Stage caveEntrance = new Stage(@"\TBQuestGFX\Rooms\Cave\caveEntranceDay.png", caveEnteranceObjects) { Music = @"\TBQuestMusic\Fields\Spirit of the Girl.mp3" };
        public static Stage caveExitPlain = new Stage(@"\TBQuestGFX\Rooms\Cave\caveExitPlain.png", caveExitObjects) { Music = @"\TBQuestMusic\Plains\Andreas Theme.mp3" };
        public static Stage caveLightDark = new Stage(@"\TBQuestGFX\Rooms\Cave\caveLightDark.png", new List<Object>()) { Music = @"\TBQuestMusic\Cave\Night Cave.mp3" };
        public static Stage caveDarkLight = new Stage(@"\TBQuestGFX\Rooms\Cave\caveDarkLight.png", new List<Object>()) { Music = @"\TBQuestMusic\Cave\Night Cave.mp3" };
        #endregion

        #region Plains Maps
        public static Stage plains = new Stage(@"\TBQuestGFX\Rooms\Plains\plain1.png", new List<Object>()) { Spawns = plainsMobs, Music = @"\TBQuestMusic\Plains\Andreas Theme.mp3" };
        public static Stage plainsDeadWoods = new Stage(@"\TBQuestGFX\Rooms\Plains\plain1DeadWoods.png", new List<Object>()) { Music = @"\TBQuestMusic\Plains\Andreas Theme.mp3" };
        #endregion

        #region Dead Woods
        public static Stage deadWoods = new Stage(@"\TBQuestGFX\Rooms\Forest\deadWoods.png", new List<Object>()) { Spawns = deadWoodsMobs, Music = @"\TBQuestMusic\Spooky Forest\ghosts of dreams_2.mp3" };
        public static Stage thickDeadWoods = new Stage(@"\TBQuestGFX\Rooms\Forest\thickDeadWoods.png", new List<Object>()) { Music = @"\TBQuestMusic\Spooky Forest\ghosts of dreams_2.mp3", Boss = Monsters.ghostyboss };
        public static Stage deadWoodsPlains = new Stage(@"\TBQuestGFX\Rooms\Forest\deadWoodsPlain1.png", new List<Object>());
        #endregion

        #region Second Town

        static Misc castleKey = new Misc(Sprites.sprite["key"])
        {
            Location = new int[2] { 25, 100 },
            Name = "Castle Key",
            Color = ConsoleColor.Yellow,
            CanDrop = false
        };

        private static List<Object> castleEnterObjects = new List<Object>()
        {
            //Usable/Misc Objects
            new Potion(Sprites.sprite["potion1"]) {
                Location = new int[2]{ 25, 130 },
                Name = "Blister Brew",
                EffectStrings = new string[1] { "1000" },
                Use = new ItemMethod(Delegates.AddAtk),
                Description = "This bottle gives you 1000 more attack!",
                Color = ConsoleColor.Cyan
            },

            new Potion(Sprites.sprite["potion2"]) {
                Location = new int[2]{ 25, 70 },
                Name = "Healing Potion",
                EffectStrings = new string[1] { "50" },
                Use = new ItemMethod(Delegates.AddHP),
                Description = "This potion will increase your HP by 50.",
                Color = ConsoleColor.Red
            },

            new Civilian(Sprites.sprite["farmer2"])
            {
                Location = new int[2]{ 25, 145 },
                Color = ConsoleColor.DarkYellow,
                Name = "Farmer Dude",
                Dialogue = new List<string>() { "Here take this.", "Didn't I already give you something.", "Hmm..." },
                Layer = 1,
                Gift = castleKey
            },

            //Doors
            new Door(Sprites.sprite["castleDoorClosed"]) {
                Location = new int[2]{ 20, 86 },
                Name = "Castle Door",
                WarpMap = "Castle Dungeon",
                WarpX = 10,
                WarpY = 26,
                DoorKey = castleKey,
                IsLocked = true,
                DoorOpen = Sprites.sprite["castleDoorOpen"]
            }
        };

        public static Stage townSecondEnterance = new Stage(@"\TBQuestGFX\Rooms\Towns\town2enterance.png", new List<Object>());
        public static Stage townSecond = new Stage(@"\TBQuestGFX\Rooms\Towns\town2.png", new List<Object>());
        public static Stage townSecondTavern = new Stage(@"\TBQuestGFX\Rooms\Towns\tavern2day.png", new List<Object>());
        public static Stage townSecondForge = new Stage(@"\TBQuestGFX\Rooms\Towns\itemandforge.png", new List<Object>());
        public static Stage townSecondCastle = new Stage(@"\TBQuestGFX\Rooms\Towns\castle.png", castleEnterObjects);
        #endregion

        #region Dungeon Stage
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
                EffectStrings = new string[1] { "50" },
                Use = new ItemMethod(Delegates.AddExperience),
                Description = "This bottle grants you 50 experience points!",
                Color = ConsoleColor.Green
            },
            new Potion(Sprites.sprite["potion1"]) {
                Location = new int[2]{ 25, 50 },
                Name = "Life Elixer",
                EffectStrings = new string[1] { "50" },
                Use = new ItemMethod(Delegates.AddMaxHP),
                Description = "This potion will increase your max HP by 50.",
                Color = ConsoleColor.DarkRed
            },
            new Potion(Sprites.sprite["potion2"]) {
                Location = new int[2]{ 25, 70 },
                Name = "Healing Potion",
                EffectStrings = new string[1] { "50" },
                Use = new ItemMethod(Delegates.AddHP),
                Description = "This potion will increase your HP by 50.",
                Color = ConsoleColor.Red
            },

            new Misc(Sprites.sprite["infoBox"]) {
                Location = new int[2]{ 25, 20 },
                Name = "Flyer",
                EffectStrings = new string[2] { "Flyer", "Trust your king. Live by your king and you will prosper." },
                Use = new ItemMethod(Delegates.DisplayText),
                Description = "There's something written on the back: The king is a madman he can't be trusted!!!.",
                Color = ConsoleColor.DarkMagenta
            },

            //Doors
            new Door(Sprites.sprite["doorClosed"]) {
                Location = new int[2]{ 14, 140 },
                Name = "Door",
                WarpMap = "Albert's Shop",
                WarpX = 10,
                WarpY = 26,
                DoorKey = lightdunKey,
                IsLocked = true,
                DoorOpen = Sprites.sprite["door"]
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

        public static Stage lightDungeon = new Stage(@"\TBQuestGFX\Rooms\Dungeon\room1.png", lightDungeonObjects);
        public static Stage dungeonPillers = new Stage(@"\TBQuestGFX\Rooms\Dungeon\room2.png");
        public static Stage dungeonPillersDoor = new Stage(@"\TBQuestGFX\Rooms\Dungeon\room3.png");
        public static Stage ditherDungeon = new Stage(@"\TBQuestGFX\Rooms\Dungeon\dungeon2-2.png");
        public static Stage darkDitherDungeon = new Stage(@"\TBQuestGFX\Rooms\Dungeon\dungeon1-2.png");
        public static Stage finalBossFight = new Stage(@"\TBQuestGFX\Rooms\Dungeon\player_start.png") { Boss = Monsters.kingboss };
        #endregion

        public static Stage map = new Stage(@"\TBQuestGFX\worldmap.png", new List<Object>());

    }
}
