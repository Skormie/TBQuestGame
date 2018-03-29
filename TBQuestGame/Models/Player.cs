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
        private bool _playerDisplayed;
        private List<Object> _inventory;
        private bool _inventoryInit;
        private bool _itemInit;
        private int[] _curserPos = new int[2];
        private int _inventoryOffset;

        public int InventoryOffset
        {
            get { return _inventoryOffset; }
            set { _inventoryOffset = value; }
        }


        public int[] CurserPos
        {
            get { return _curserPos; }
            set { _curserPos = value; }
        }


        public bool ItemInit
        {
            get { return _itemInit; }
            set { _itemInit = value; }
        }

        public bool InventoryInit
        {
            get { return _inventoryInit; }
            set { _inventoryInit = value; }
        }

        public List<Object> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }


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

        public bool PlayerDisplayed
        {
            get { return _playerDisplayed; }
            set { _playerDisplayed = value; }
        }

        public Player( int x, int y, int width, int height, List<List<string>> sprite, int layer = 0  ) : base( x, y, width, height, sprite, layer)
        {
            Inventory = new List<Object>();
            Sprite = _sprites;
        }

        public override void PrintObject(ConsoleView cv, int layer = 0, int animation = 0, int sprite = 0)
        {
            int i = 0;
            int k = 2;
            Tick++;
            int initAni = Animation;
            if (CurrentAnim != Animation)
            {
                CurrentAnim = Animation;
                CurrentFrame = 0;
            }
            else if (Tick % 15 == 0)
            {
                CurrentFrame = ++CurrentFrame % _sprites[Animation].Count();
                if(Animation == 1 && CurrentFrame == 2)
                {
                    Animation = 2;
                }
            }
            foreach (char item in _sprites[Animation][CurrentFrame])
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
