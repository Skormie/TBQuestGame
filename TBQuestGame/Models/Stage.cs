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

        public Stage( string background, List<Object> objects )
        {
            _background = background;
            _objects = objects;
        }

    }

}
