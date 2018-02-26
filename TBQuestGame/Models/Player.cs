using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TBQuestGame
{
    public class Player : Object
    {

        private List<List<string>> _sprites = new List<List<string>>()
        {
            new List<string>()
            {
                "\0          \n" + //Idle Right
                "\0   ███    \n" +
                "\0    ██    \n" +
                "\0 ██ ██  █ \n" +
                "\0 ██    █  \n" +
                "\0   ██ █   \n" +
                "\0  █  █    \n" +
                "\0 ██  ██   \n"
            },
            new List<string>()
            {
                "\0          \n" + // Walk Right Startup Frame 1
                "\0   ███    \n" +
                "\0    ██    \n" +
                "\0 ██ ██  █ \n" +
                "\0 ██    █  \n" +
                "\0   ██ █   \n" +
                "\0  █  █    \n" +
                "\0  ██ ██   \n",
                "          \n" + // Walk Right Startup Frame 2
                "   ███  █ \n" +
                "    ██  █ \n" +
                "  ██ █ █  \n" +
                "  ██   █  \n" +
                "   ███    \n" +
                "  ██  █   \n" +
                "  █   ██  \n"
            },
            new List<string>()
            {
                "\0          \0\n" + // Walk Right Frame 3
                "\0   ███ █  \0\n" +
                "\0     █ █  \0\n" +
                "\0   ██  █  \0\n" +
                "\0   ██  █  \0\n" +
                "\0 ██  █    \0\n" +
                "\0  ██ █    \0\n" +
                "\0     ██   \0\n",
                "          \n" + // Walk Right Frame 4
                "   ███ █  \n" +
                "     █ █  \n" +
                "   ██  █  \n" +
                "   ██  █  \n" +
                "     █    \n" +
                "   ██     \n" +
                "   ███    \n",
                "          \n" + // Walk Right Frame 5
                "   ███ █  \n" +
                "     █ █  \n" +
                "   ██  █  \n" +
                "   ██  █  \n" +
                "  ███     \n" +
                "   ██     \n" +
                "    ██    \n",
                "          \n" + // Walk Right Frame 4
                "   ███ █  \n" +
                "     █ █  \n" +
                "   ██  █  \n" +
                "   ██  █  \n" +
                "     █    \n" +
                "   ██     \n" +
                "   ███    \n"
            },
            new List<string>() {
                "\0          \n" + // Jumping Animation
                "\0   ███  █ \n" +
                "\0 ██ ██  █ \n" +
                "\0 ██ ██ █  \n" +
                "\0   █   █  \n" +
                "\0   ██     \n" +
                "\0  ██  █   \n" +
                "\0  █   ██  \n"
            }
        };

        public Player( int x, int y, int width, int height, List<List<string>> sprite  ) : base( x, y, width, height, sprite)
        {
            Sprite = _sprites;
        }
    }
}
