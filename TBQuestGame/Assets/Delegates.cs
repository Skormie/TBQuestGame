using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    delegate void ItemMethod(Controller ctrl, params string[] a);

    public class Delegates
    {
        public static void EmptyEffect(Controller ctrl, params string[] b)
        {
            ctrl.scene.DisplayText("Use Item:", "This item has no effect!");
        }

        public static void DisplayText(Controller ctrl, params string[] c)
        {
            ctrl.scene.DisplayText(c[0], c[1]);
        }

        public static void AddMaxHP(Controller ctrl, params string[] c)
        {
            int maxHP = int.Parse(c[0]);
            ctrl.player.MaxHealth += maxHP;
            ctrl.RemoveInventoryItem();
            ctrl.scene.DisplayHealthBar();
        }

        public static void AddSpeed(Controller ctrl, params string[] c)
        {
            int speed = int.Parse(c[0]);
            ctrl.player.Speed = speed;
            ctrl.RemoveInventoryItem();
        }

        public static void AddAtk(Controller ctrl, params string[] c)
        {
            int atk = int.Parse(c[0]);
            ctrl.player.Attack += atk;
            ctrl.RemoveInventoryItem();
            ctrl.scene.DisplayHealthBar();
        }

        public static void AddHP(Controller ctrl, params string[] d)
        {
            int hp = int.Parse(d[0]);
            ctrl.player.Health += hp;
            ctrl.RemoveInventoryItem();
            ctrl.scene.DisplayHealthBar();
        }

        public static void AddExperience(Controller ctrl, params string[] d)
        {
            int exp = int.Parse(d[0]);
            ctrl.player.Experience += exp;
            ctrl.RemoveInventoryItem();
            ctrl.scene.DisplayPlayerInfo();
        }
    }
}
