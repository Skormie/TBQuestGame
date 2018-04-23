using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Character : Object
    {
        public int Gold { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public int NextExperience { get; set; } = 10;
        public int Level { get; set; }
    }
}
