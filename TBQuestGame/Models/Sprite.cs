using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Sprite
    {
        public List<string> Sprites { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Sprite(List<string> sprites)
        {
            Sprites = sprites;
            Height = Sprites[0].Length - Sprites[0].Replace("\n", "").Length;
            Width = Sprites[0].IndexOf('\n') * 2;
        }
    }
}
