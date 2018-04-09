using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class Potion : Lootable
    {
        public int heal;
        public new ItemMethod Use;

        public Potion() { }

        public Potion(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
        }
    }
}
