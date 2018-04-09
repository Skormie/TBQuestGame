using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    abstract class Lootable : Object
    {
        public string Description { get; set; }
        public bool CanDrop { get; set; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }
        public int EffectInt { get; set; }

        public virtual void Use() { }

        void Look()
        {
            
        }

        void Drop()
        {

        }

    }
}
