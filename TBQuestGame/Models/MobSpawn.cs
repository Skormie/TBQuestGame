using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    //class MobSpawn
    //{
    //    public Enemy _mob;
    //    public int _chance;

    //    MobSpawn( Enemy mob, int chance )
    //    {
    //        _mob = mob;
    //        _chance = chance;
    //    }
    //}

    public struct MobSpawn
    {
        public Enemy _mob;
        public int _chance;

        public MobSpawn( Enemy mob, int chance )
        {
            _mob = mob;
            _chance = chance;
        }
    }
}
