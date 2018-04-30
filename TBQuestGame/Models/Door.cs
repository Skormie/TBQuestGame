using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    class Door : Object
    {
        public string WarpMap { get; set; }
        public int WarpX { get; set; }
        public int WarpY { get; set; }
        public int WarpZ { get; set; }
        public bool IsLocked { get; set; }
        public Object DoorKey { get; set; }
        public Sprite DoorOpen { get; set; }

        public Door() { }

        public Door(Sprite sprite, int height, int width)
        {
            Width = width;
            Height = height;
            Sprite = sprite.Sprites;
        }

        public Door(Sprite sprite)
        {
            Width = sprite.Width;
            Height = sprite.Height;
            Sprite = sprite.Sprites;
        }

        public int Open( Player player, Controller control, Object passedKey = null)
        {
            if (!IsLocked)
            {
                if (!Area.maps[player.Stage][player.StageDepth].Indoors)
                {
                    player.LastMapXYZ[0] = player.Stage;
                    player.LastMapXYZ[1] = player.Location[1];
                    player.LastMapXYZ[2] = player.Location[0];
                    player.LastMapXYZ[3] = player.StageDepth;
                }
                else
                    Array.Clear(player.LastMapXYZ, 0, 4);

                player.Location[1] = WarpX;
                player.Location[0] = WarpY;
                player.Stage = control.GetMapIndex(WarpMap);
                player.StageDepth = WarpZ;
                control.LoadStage();
                return 0;
            }
            else if (player.Inventory.Contains(DoorKey))
            {
                IsLocked = false;
                player.Inventory.Remove(DoorKey);
                control.scene.DisplayText("Object Used!", "You used " + DoorKey.Name + " to unlock " + Name + "!", 10, 50, 20, 40, 4, 8);
                if (DoorOpen != null)
                {
                    Sprite = DoorOpen.Sprites;
                    this.PrintObject(control.scene);
                    control.scene.DisplayObjectSceneLayer(this, Layer);
                }
            } else
                control.scene.DisplayText("Door", "This " + Name + " seems to be locked!", 10, 50, 20, 40, 4, 8);
            return -1;
        }
    }
}
