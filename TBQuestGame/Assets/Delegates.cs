using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    delegate void ItemMethod(Player player, int a);

    public class Delegates
    {
        public static void AddMaxHP(Player player, int b)
        {
            player.MaxHealth += b;
        }
        public static void AddHP(Player player, int c)
        {
            player.Health += c;
        }
    }
}
