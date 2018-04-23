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
            }
        };
    }
}
