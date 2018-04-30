using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    static class Monsters
    {
        public static Enemy goblin = new Enemy(Sprites.sprite["goblin"])
        {
            Name = "Goblin",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 25
        };

        public static Enemy ghost = new Enemy(Sprites.sprite["ghost"])
        {
            Name = "Ghosty",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 40
        };

        public static Enemy bandit = new Enemy(Sprites.sprite["bandit"])
        {
            Name = "Bandit",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 100
        };

        public static Enemy mage = new Enemy(Sprites.sprite["mage"])
        {
            Name = "Mage",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 200
        };

        public static Enemy skeleton = new Enemy(Sprites.sprite["skeleton"])
        {
            Name = "Skeleton",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 100
        };

        public static Enemy skeleton2 = new Enemy(Sprites.sprite["skeleton2"])
        {
            Name = "Skeleton",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 140
        };

        public static Enemy slime = new Enemy(Sprites.sprite["slime"])
        {
            Name = "Slime",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 20
        };

        public static Enemy spider = new Enemy(Sprites.sprite["spider"])
        {
            Name = "Spider",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 50
        };
    }
}
