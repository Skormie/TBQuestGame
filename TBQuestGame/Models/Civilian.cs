using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class Civilian : NPC, ISpeak
    {
        public List<string> Dialogue { get; set; }

        public Civilian(Sprite sprite) : base(sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
        }

        public string Speak()
        {
            if(Dialogue != null)
            {
                return GetMessage();
            }
            return $"My name is {base.Name}.";
        }

        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Dialogue.Count());
            return Dialogue[messageIndex];
        }
    }
}
