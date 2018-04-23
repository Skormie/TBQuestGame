using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class ObjectKey : Lootable
    {
        public override bool CanDrop { get; set; }

        public override bool CanDestroy { get; set; }

        public override int Experience { get; set; } = 100;

        public ObjectKey() { CanDrop = false; CanDestroy = false; }

        public ObjectKey(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
            CanDrop = false;
            CanDestroy = false;
        }
    }
}
