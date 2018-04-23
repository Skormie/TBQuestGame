using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    delegate void ItemMethod(Controller ctrl, params int[] a);

    public class Delegates
    {
        public static void EmptyEffect(Controller ctrl, params int[] b)
        {
            ctrl.scene.DisplayText("Use Item:", "This item has no effect!");
        }

        public static void AddMaxHP(Controller ctrl, params int[] c)
        {
            ctrl.player.MaxHealth += c[0];
            ctrl.RemoveInventoryItem();
            ctrl.scene.DisplayHealthBar();
        }

        public static void AddHP(Controller ctrl, params int[] d)
        {
            ctrl.player.Health += d[0];
            ctrl.RemoveInventoryItem();
            ctrl.scene.DisplayHealthBar();
        }

        public static void AddExperience(Controller ctrl, params int[] d)
        {
            ctrl.player.Experience += d[0];
            ctrl.RemoveInventoryItem();
            ctrl.scene.DisplayPlayerInfo();
        }
    }
}
