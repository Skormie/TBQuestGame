using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Enemy : NPC
    {

        public Enemy(Sprite sprite) : base(sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
            MaxHealth = Health;
        }

        public Enemy(Enemy mob) : base(mob)
        {
            Width = mob.Width;
            Height = mob.Height;
            Sprite = mob.Sprite;
            Attack = mob.Attack;
            Color = mob.Color;
            Location = mob.Location;
            Health = mob.Health;
            Gold = mob.Gold;
            Name = mob.Name;
            Experience = mob.Experience;
            MaxHealth = Health;
        }
    }
}
