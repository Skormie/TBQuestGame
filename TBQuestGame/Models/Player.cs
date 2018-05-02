using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TBQuestGame
{
    public class Player : Character
    {
        private bool _playerDisplayed;
        private List<Object> _inventory;
        private bool _inventoryInit;
        private int[] _curserPos = new int[2];
        private int _inventoryOffset;

        public int Speed { get; set; } = 7;

        public bool Turn { get; set; } = true;

        public bool battleInit { get; set; } = false;

        public int[] BattleMapXYZ { get; set; } = new int[4];

        public int[] LastMapXYZ { get; set; } = new int[4];

        public override int Experience { get; set; } = 0;

        public int Stage { get; set; }

        public int StageDepth { get; set; }

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

        public bool InventoryInit
        {
            get { return _inventoryInit; }
            set { _inventoryInit = value; }
        }

        public List<Object> Inventory
        {
            get { return _inventory; }
            set
            {
                OnObjectAddedToInventory();
                _inventory = value;
            }
        }

        // Sprites for the player.
        #region Player Sprites
        private List<List<string>> _sprites = new List<List<string>>()
        {
            new List<string>() //0
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
            new List<string>() //1
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
            new List<string>() //2
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
            new List<string>() //3
            {
                "\0          \n" + // Jumping Animation
                "\0   ███  █ \n" +
                "\0 ██ ██  █ \n" +
                "\0 ██ ██ █  \n" +
                "\0   █   █  \n" +
                "\0   ██     \n" +
                "\0  ██  █   \n" +
                "\0  █   ██  \n"
            },
            new List<string>() // Left Animations. 4
            {
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\hero.png", true)
            },
            new List<string>() // 5
            {
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\heroR1.png", true),
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\heroR2.png", true),
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\heroR2.png", true)
            },
            new List<string>() // 6
            {
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\heroR3.png", true),
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\heroR4.png", true),
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\heroR5.png", true),
                Image.ConsoleReadImage(@"\TBQuestGFX\Sprites\HeroLeft\heroR4.png", true)
            }
        };
        #endregion

        public bool PlayerDisplayed
        {
            get { return _playerDisplayed; }
            set { _playerDisplayed = value; }
        }

        public override void PrintObject(ConsoleView cv, int layer = 0)
        {
            int i = 0;
            int k = 2;
            Tick++;
            if (CurrentAnim != Animation)
            {
                CurrentAnim = Animation;
                CurrentFrame = 0;
            }
            else if (Tick % 15 == 0)
            {
                CurrentFrame = ++CurrentFrame % _sprites[Animation].Count();
                if(Animation == 1 && CurrentFrame == 2)
                    Animation = 2;
                else if(Animation == 5 && CurrentFrame == 2)
                    Animation = 6;
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
