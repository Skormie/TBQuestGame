using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class Misc : Lootable
    {
        public override void Use()
        {
            throw new NotImplementedException();
        }

        public Misc() { }

        public Misc(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
        }
    }
}
