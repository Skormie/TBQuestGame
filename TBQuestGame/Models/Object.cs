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
        private bool print = false;
        private int width;
        private int height;
        private int[] location = new int[] { 0, 0 }; // row, column
        private int _animation;

        //static System.Timers.Timer timer = new System.Timers.Timer();

        private List<List<string>> _sprites;

        //"   █████    \n"+
        //"  █████████ \n" +
        //"  ███████   \n" +
        //" ██████████ \n" +
        //" ███████████\n" +
        //" ██████████ \n" +
        //"   ███████  \n" +
        //"  ██████    \n" +
        //" ██████████ \n" +
        //"████████████\n" +
        //"████████████\n" +
        //"████████████\n" +
        //"████████████\n" +
        //"  ███  ███  \n" +
        //" ███    ███ \n" +
        //"████    ████";
        #endregion

        #region Properties

        public int Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public bool Print
        {
            get { return print; }
            set { print = value; }
        }

        public int[] Location
        {
            get { return location; }
            set { location = value; }
        }

        public virtual List<List<string>> Sprite
        {
            get { return _sprites; }
            set { _sprites = value; }
        }

        #endregion

        public Object(int x, int y, int width, int height, List<List<string>> sprite)
        {
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            //timer.Interval = 0.1;
            //timer.Start();
            Location[1] = x;
            Location[0] = y;
            Width = width;
            Height = height;
            Sprite = sprite;
        }

        #region Methods
        void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //timer.Stop();
            //timer.Start();
        }

        public virtual void PrintObject(ConsoleView cv, int layer = 0)
        {
            int i = 0;
            int k = 2;
            int initAni = Animation;
            foreach (char item in _sprites[Animation][0])
            {
                if (item != '\n')
                {
                    cv.SetMapInfo(location[1] + k, location[0] + i, layer, item);
                    cv.SetMapInfo(location[1] + k + 1, location[0] + i, layer, item);
                }
                else
                {
                    i++;
                    k = 0;
                }
                k += 2;
            }
            i = 0;
        }
        #endregion
    }
}
