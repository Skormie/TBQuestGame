using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    abstract class Lootable : Object
    {
        public ItemMethod Use = Delegates.EmptyEffect;

        private string[] effectStrings = new string[] { "0" };

        private int layer = ConsoleView.itmLayer;

        public int SellPrice { get; set; }

        public int BuyPrice { get; set; }

        public abstract bool CanDrop { get; set; }

        public abstract bool CanDestroy { get; set; }

        public override int Layer
        {
            get { return layer; }
            set { layer = value; }
        }

        public string[] EffectStrings
        {
            get { return effectStrings; }
            set { effectStrings = value; }
        }

        void Look()
        {
            
        }

        void Drop()
        {

        }

    }
}
