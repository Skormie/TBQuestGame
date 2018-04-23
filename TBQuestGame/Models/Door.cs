using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class Door : Object
    {
        public int WarpMap { get; set; }
        public int WarpX { get; set; }
        public int WarpY { get; set; }
        public bool IsLocked { get; set; }
        public Object DoorKey { get; set; }

        public Door() { }

        public Door(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
        }

        public int Open( Player player, Controller control, ConsoleView console, Object passedKey = null)
        {
            if (!IsLocked)
            {
                player.Location[1] = WarpX;
                player.Location[0] = WarpY;
                control.LoadStage(WarpMap);
                return WarpMap;
            }
            else if (player.Inventory.Contains(DoorKey))
            {
                IsLocked = false;
                player.Inventory.Remove(DoorKey);
                console.DisplayText("Object Used!", "You used " + DoorKey.Name + " to unlock " + Name + "!", 10, 50, 20, 40, 4, 8);
            } else
                console.DisplayText("Door", "This " + Name + " seems to be locked!", 10, 50, 20, 40, 4, 8);
            return -1;
        }
    }
}
