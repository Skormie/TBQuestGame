using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{

    public class Stage
    {
        private string _background;

        private List<Object> _objects;

        private bool canPassRight;

        private bool canPassLeft;

        public string Music { get; set; }

        public List<MobSpawn> Spawns { get; set; } = new List<MobSpawn>();

        public Warp MapWarpRight { get; set; }

        public Warp MapWarpLeft { get; set; }

        public int MapBoundsRight { get; set; } = ConsoleView._windowWidth - 25;

        public int MapBoundsLeft { get; set; } = 0;

        public bool Indoors { get; set; } = false;

        public bool CanPassLeft
        {
            get { return canPassLeft; }
            set { canPassLeft = value; }
        }

        public bool CanPassRight
        {
            get { return canPassRight; }
            set { canPassRight = value; }
        }

        public List<Object> Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }

        public string Background
        {
            get { return _background; }
            set { _background = value; }
        }

        Stage() { }

        public Stage( Stage copy, bool copyObjects = true )
        {
            _background = copy._background;
            canPassLeft = copy.canPassLeft;
            canPassRight = copy.canPassRight;
            _objects = copyObjects ? new List<Object>( copy.Objects ) : new List<Object>();
            Spawns = copy.Spawns;
        }

        public Stage( string background, List<Object> objects = null )
        {
            _background = background;
            _objects = objects == null ? new List<Object>() : objects;
        }

    }

}
