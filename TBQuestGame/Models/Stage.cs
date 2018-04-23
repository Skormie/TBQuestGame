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

        public Stage( Stage copy )
        {
            _background = copy._background;
            canPassLeft = copy.canPassLeft;
            canPassRight = copy.canPassRight;
            _objects = new List<Object>();
        }

        public Stage( string background, List<Object> objects )
        {
            _background = background;
            _objects = objects;
        }

    }

}
