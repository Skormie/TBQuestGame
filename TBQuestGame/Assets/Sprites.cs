using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public static class Sprites
    {
        public static Dictionary<string, Sprite> sprite = new Dictionary<string, Sprite>()
        {
            { "empty", new Sprite
            (
                new List<string>() {
                    ""
                }
            )
            },
            { "torch", new Sprite
            (
                new List<string>() {
                    "        \n" +
                    "    █   \n" +
                    "   █ █  \n" +
                    "  █ █ █ \n" +
                    " █ █  █ \n" +
                    " █    █ \n" +
                    "  █  █  \n" +
                    " ██████ \n" +
                    "  █  █  \n" +
                    "   ██   \n" +
                    "        \n"
                ,
                    "        \n" +
                    "   █    \n" +
                    "  █ █   \n" +
                    " █ █ █  \n" +
                    " █  █ █ \n" +
                    " █    █ \n" +
                    "  █  █  \n" +
                    " ██████ \n" +
                    "  █  █  \n" +
                    "   ██   \n" +
                    "        \n"
                }
            )
            },
            { "shinyThing", new Sprite
            (
                new List<string>() {
                    "         \n" +
                    "         \n" +
                    "    █    \n" +
                    "   ███   \n" +
                    "    █    \n" +
                    "         \n" +
                    "         \n"
                ,
                    "         \n" +
                    "    █    \n" +
                    "         \n" +
                    " █  █  █ \n" +
                    "         \n" +
                    "    █    \n" +
                    "         \n"
                }
            )
            },
            { "potion1", new Sprite
            (
                new List<string>() {
                    "     \n" +
                    "  █  \n" +
                    "  █  \n" +
                    " █ █ \n" +
                    " ███ \n" +
                    "     \n"
                }
            )
            },
            { "potion2", new Sprite
            (
                new List<string>() {
                    "       \n" +
                    "   █   \n" +
                    "   █   \n" +
                    "  █ █  \n" +
                    " █   █ \n" +
                    " █████ \n" +
                    "       \n"
                }
            )
            },
            { "potion3", new Sprite
            (
                new List<string>() {
                    "       \n" +
                    "   █   \n" +
                    "  █ █  \n" +
                    " █   █ \n" +
                    " █   █ \n" +
                    " █████ \n" +
                    "       \n"
                }
            )
            },
            {
                "infoBox", new Sprite(@"\TBQuestGFX\Lootable Objects\infobox.png")
            },
            { "door", new Sprite
            (
                new List<string>() {
                    "  █   █  █   █  \n" +
                    "   █ █ ██ █ █   \n" +
                    "█ █ █ ████ █ █ █\n" +
                    " █ █ ██████ █ █ \n" +
                    "█ █ █      █ █ █\n" +
                    " ███        ███ \n" +
                    "█ █          █ █\n" +
                    " ██          ██ \n" +
                    "█ █          █ █\n" +
                    " ██          ██ \n" +
                    "█ █          █ █\n" +
                    " ██          ██ \n" +
                    "█ █          █ █\n" +
                    " ██          ██ \n" +
                    "█ █          █ █\n" +
                    " ██          ██ \n" +
                    "█ █          █ █\n" +
                    " ██          ██ \n" +
                    "█ █          █ █\n"
                }
            )
            },
            {
                "doorClosed", new Sprite(@"\TBQuestGFX\Rooms\Dungeon\doorclosed.png")
            },
            {
                "caveDoor", new Sprite(@"\TBQuestGFX\Rooms\Cave\caveDoor.png")
            },
            {
                "forestDoor", new Sprite(@"\TBQuestGFX\Rooms\Forest\forestDoor.png")
            },
            {
                "deadWoodsDoor", new Sprite(@"\TBQuestGFX\Rooms\Forest\deadwoodDoor.png")
            },
            { "key", new Sprite
            (
                new List<string>() {
                    "        \n" +
                    " ██     \n" +
                    " █ ████ \n" +
                    " ██ █ █ \n"
                }
            )
            },
            { "man", new Sprite
            (
                new List<string>()
                {
                    "      \n" +
                    "  ███ \n" +
                    "  ███ \n" +
                    "  ██  \n" +
                    "      \n" +
                    "  ███ \n" +
                    "  ███ \n" +
                    "  █ █ \n" +
                    " ██ █ \n"
                }
            )
            },
            { "woman", new Sprite
            (
                new List<string>()
                {
                    "       \n" +
                    "  ███  \n" +
                    "  ███  \n" +
                    "  ███  \n" +
                    "    ██ \n" +
                    " ███   \n" +
                    "  ██   \n" +
                    "  ███  \n" +
                    "  ███  \n"
                }
            )
            },
            { "farmer1", new Sprite
            (
                new List<string>()
                {
                    "        \n" +
                    "   ███  \n" +
                    " █████  \n" +
                    "   ████ \n" +
                    "  ███   \n" +
                    "  ██ █  \n" +
                    "    ██  \n" +
                    "   █  █ \n" +
                    "  ██ ██ \n"
                }
            )
            },
            { "farmer2", new Sprite
            (
                new List<string>()
                {
                    " █ █      \n" +
                    " █ █ ███  \n" +
                    "  ██████  \n" +
                    "  █  ████ \n" +
                    "  █ ███   \n" +
                    "  █ ██ █  \n" +
                    "  █   ██  \n" +
                    "  █  █  █ \n" +
                    "  █ ██ ██ \n"
                }
            )
            },
            { "docter", new Sprite
            (
                new List<string>()
                {
                    "        \n" +
                    "   ███  \n" +
                    "   ███  \n" +
                    " ████   \n" +
                    "     ██ \n" +
                    "    ███ \n" +
                    "    ███ \n" +
                    "    ███ \n"
                }
            )
            },
            {
                "goblin", new Sprite(@"\TBQuestGFX\Monster\goblin.png")
            },
            {
                "ghost", new Sprite(@"\TBQuestGFX\Monster\ghost.png")
            },
            {
                "bandit", new Sprite(@"\TBQuestGFX\Monster\bandit.png")
            },
            {
                "mage", new Sprite(@"\TBQuestGFX\Monster\mage.png")
            },
            {
                "skeleton", new Sprite(@"\TBQuestGFX\Monster\skeleton.png")
            },
            {
                "skeleton2", new Sprite(@"\TBQuestGFX\Monster\skelly2.png")
            },
            {
                "slime", new Sprite(@"\TBQuestGFX\Monster\slime.png")
            },
            {
                "spider", new Sprite(@"\TBQuestGFX\Monster\spider.png")
            },
            {
                "ghostboss", new Sprite(@"\TBQuestGFX\Boss\ghostboss.png")
            },
            {
                "kingboss", new Sprite(@"\TBQuestGFX\Boss\kingboss.png")
            },
            {
                "spiderboss", new Sprite(@"\TBQuestGFX\Boss\spiderboss.png")
            },
        };
    }
}
