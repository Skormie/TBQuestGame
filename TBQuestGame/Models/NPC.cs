using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class NPC : Character
    {
        public string Dialogue = "";

        public Object Gift { get; set; }

        public NPC(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
        }

        public NPC(Enemy mob)
        {
            Width = mob.Width;
            Height = mob.Height;
            Sprite = mob.Sprite;

            MaxHealth = Health;
        }
    }
}
