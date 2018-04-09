using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Object
    {
        #region Fields
        private bool _print = false;
        private int _width;
        private int _height;
        private int[] _location = new int[] { 0, 0 }; // row, column
        private int _animation;
        private int _currentAnim;
        private int _currentFrame;
        private int _tick;
        private int _layer = ConsoleView.bkgLayer;
        private string _name;
        private int[] _inventoryLoc = new int[2];
        private List<string> _sprites;
        #endregion

        #region Properties
        public int[] InventoryLoc
        {
            get { return _inventoryLoc; }
            set { _inventoryLoc = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Tick
        {
            get { return _tick; }
            set { _tick = value; }
        }

        public int Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public int CurrentFrame
        {
            get { return _currentFrame; }
            set { _currentFrame = value; }
        }

        public int CurrentAnim
        {
            get { return _currentAnim; }
            set { _currentAnim = value; }
        }

        public int Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public bool Print
        {
            get { return _print; }
            set { _print = value; }
        }

        // Y X
        public int[] Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public virtual List<string> Sprite
        {
            get { return _sprites; }
            set { _sprites = value; }
        }

        #endregion

        public Object() { }

        public Object(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
        }

        #region Methods
        public int GetObjectFrame()
        {
            return (++_currentFrame % Sprite.Count()) + Layer;
        }

        public virtual void PrintObject(ConsoleView cv, int layer = ConsoleView.bkgLayer)
        {
            int i = 0;
            int k = 2;
            layer = Layer;
            foreach (string String in Sprite)
            {
                foreach (char item in String)
                {
                    if (item != '\n')
                    {
                        cv.SetMapInfo(_location[1] + k, _location[0] + i, layer, item);
                        cv.SetMapInfo(_location[1] + k + 1, _location[0] + i, layer, item);
                    }
                    else
                    {
                        i++;
                        k = 0;
                    }
                    k += 2;
                }
                i = 0;
                layer++;
            }
        }
        #endregion
    }
}
