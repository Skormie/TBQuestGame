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
        int current_anim;
        int current_frame;
        int tick = 0;

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
                "\0          \n" + // Walk Right Startup Frame 2
                "\0   ███  █ \n" +
                "\0    ██  █ \n" +
                "\0  ██ █ █  \n" +
                "\0  ██   █  \n" +
                "\0   ███    \n" +
                "\0  ██  █   \n" +
                "\0  █   ██  \n",
                "\0          \n" + // Walk Right Startup Frame 2
                "\0   ███  █ \n" +
                "\0    ██  █ \n" +
                "\0  ██ █ █  \n" +
                "\0  ██   █  \n" +
                "\0   ███    \n" +
                "\0  ██  █   \n" +
                "\0  █   ██  \n"
            },
            new List<string>()
            {
                "\0          \n" + // Walk Right Frame 3
                "\0   ███ █  \n" +
                "\0     █ █  \n" +
                "\0   ██  █  \n" +
                "\0   ██  █  \n" +
                "\0 ██  █    \n" +
                "\0  ██ █    \n" +
                "\0     ██   \n",
                "\0          \n" + // Walk Right Frame 4
                "\0   ███ █  \n" +
                "\0     █ █  \n" +
                "\0   ██  █  \n" +
                "\0   ██  █  \n" +
                "\0     █    \n" +
                "\0   ██     \n" +
                "\0   ███    \n",
                "\0          \n" + // Walk Right Frame 5
                "\0   ███ █  \n" +
                "\0     █ █  \n" +
                "\0   ██  █  \n" +
                "\0   ██  █  \n" +
                "\0  ███     \n" +
                "\0   ██     \n" +
                "\0    ██    \n",
                "\0          \n" + // Walk Right Frame 4
                "\0   ███ █  \n" +
                "\0     █ █  \n" +
                "\0   ██  █  \n" +
                "\0   ██  █  \n" +
                "\0     █    \n" +
                "\0   ██     \n" +
                "\0   ███    \n"
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

        public override void PrintObject(ConsoleView cv, int layer = 0, int animation = 0, int sprite = 0)
        {
            int i = 0;
            int k = 2;
            tick++;
            int initAni = Animation;
            if (current_anim != Animation)
            {
                current_anim = Animation;
                current_frame = 0;
            }
            else if (tick % 15 == 0)
            {
                current_frame = ++current_frame % _sprites[Animation].Count();
                if(Animation == 1 && current_frame == 2)
                {
                    Animation = 2;
                }
            }
            foreach (char item in _sprites[Animation][current_frame])
            {
                if (item != '\n')
                {
                    cv.SetMapInfo(Location[1] + k, Location[0] + i, layer, item);
                    cv.SetMapInfo(Location[1] + k + 1, Location[0] + i, layer, item);
                }
                else
                {
                    i++;
                    k = 0;
                }
                k += 2;
            }
            i = 0;
        }
    }
}
