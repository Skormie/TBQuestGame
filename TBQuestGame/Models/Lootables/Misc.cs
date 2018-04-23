using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class Misc : Lootable
    {
        public override bool CanDrop { get; set; }
        public override bool CanDestroy { get; set; }

        public Misc()
        {
            CanDrop = true;
            CanDestroy = true;
        }

        public Misc(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
            CanDrop = true;
            CanDestroy = true;
        }
    }
}
