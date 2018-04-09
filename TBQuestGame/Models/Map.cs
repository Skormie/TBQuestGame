using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Map
    {
        private List<Stage> universe;

        public List<Stage> Universe
        {
            get { return universe; }
            set { universe = value; }
        }


        public Map()
        {
            universe = new List<Stage>
            {
                Stages.shop,
                Stages.lightDungeon,
                Stages.ditherDungeon,
                Stages.field,
                Stages.field
            };
        }
    }
}