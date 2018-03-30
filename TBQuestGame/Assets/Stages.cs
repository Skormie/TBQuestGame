using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public static class Stages
    {

        private static List<Object> fieldObjects = new List<Object>()
        {
            new Object() { Location = new int[2]{ 10, 121 }, Width = 16, Height = 11, Sprite = Sprites.sprite["torch"] },
            new Object() { Location = new int[2]{ 10, 25 }, Width = 16, Height = 11, Sprite = Sprites.sprite["torch"] },
            new Object() { Location = new int[2]{ 25, 25 }, Width = 18, Height = 7, Sprite = Sprites.sprite["shinyThing"], Name = "Shiny Thing", Layer = 3 },
            new Object() { Location = new int[2]{ 25, 25 }, Width = 18, Height = 7, Sprite = Sprites.sprite["shinyThing"], Name = "Shiny Thing2", Layer = 3 }
        };

        public static Stage field = new Stage(@"\TBQuestGFX\Rooms\Field\field1.png", fieldObjects);


        static List<Object> lightDungeonObjects = new List<Object>()
        {
            new Object() { Location = new int[2]{ 10, 121 }, Width = 16, Height = 11, Sprite = Sprites.sprite["torch"] },
            new Object() { Location = new int[2]{ 10, 25 }, Width = 16, Height = 11, Sprite = Sprites.sprite["torch"] },
            new Object() { Location = new int[2]{ 25, 25 }, Width = 18, Height = 7, Sprite = Sprites.sprite["shinyThing"], Name = "Shiny Thing", Layer = 3 },
            new Object() { Location = new int[2]{ 25, 25 }, Width = 18, Height = 7, Sprite = Sprites.sprite["shinyThing"], Name = "Shiny Thing2", Layer = 3 }
        };
        public static Stage lightDungeon = new Stage( @"\TBQuestGFX\Rooms\Dungeon\room1.png", lightDungeonObjects);

        public static Stage ditherDungeon = new Stage( @"\TBQuestGFX\Rooms\Dungeon\dungeon2-2.png", new List<Object>());

    }
}
