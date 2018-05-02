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
            Health = 25,
            Level = 5,
            Gold = 5
        };

        public static Enemy goblinGreen = new Enemy(Sprites.sprite["goblin"])
        {
            Name = "Goblin",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 25,
            Color = ConsoleColor.Green,
            Level = 10,
            Gold = 10
        };

        public static Enemy ghost = new Enemy(Sprites.sprite["ghost"])
        {
            Name = "Ghosty",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 40,
            Level = 20,
            Gold = 15
        };

        public static Enemy bandit = new Enemy(Sprites.sprite["bandit"])
        {
            Name = "Bandit",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 100,
            Level = 15,
            Gold = 20
        };

        public static Enemy mage = new Enemy(Sprites.sprite["mage"])
        {
            Name = "Mage",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 200,
            Level = 30,
            Gold = 80
        };

        public static Enemy skeleton = new Enemy(Sprites.sprite["skeleton"])
        {
            Name = "Skeleton",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 100,
            Level = 20,
            Gold = 15
        };

        public static Enemy skeleton2 = new Enemy(Sprites.sprite["skeleton2"])
        {
            Name = "Skeleton",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 140,
            Level = 25,
            Gold = 16
        };

        public static Enemy slime = new Enemy(Sprites.sprite["slime"])
        {
            Name = "Slime",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 20,
            Level = 1,
            Gold = 1,
            MaxHealth = 10
        };

        public static Enemy slimeblue = new Enemy(Sprites.sprite["slime"])
        {
            Name = "Slime",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 20,
            Color = ConsoleColor.Blue,
            Level = 3,
            Gold = 5,
            MaxHealth = 20
        };

        public static Enemy spider = new Enemy(Sprites.sprite["spider"])
        {
            Name = "Spider",
            Location = new int[2] { Controller.floor, 130 },
            Attack = 10,
            Defence = 3,
            Health = 50,
            Level = 13,
            Gold = 15,
            MaxHealth = 50
        };

        public static Enemy kingboss = new Enemy(Sprites.sprite["kingboss"])
        {
            Name = "King Greg",
            Location = new int[2] { 18, 130 },
            Attack = 100,
            Defence = 3,
            Health = 50,
            IsBoss = true,
            Color = ConsoleColor.White,
            Music = @"\TBQuestMusic\Final Boss\cereal_city.mp3",
            Level = 99,
            Gold = 1000,
            MaxHealth = 50
        };

        public static Enemy ghostyboss = new Enemy(Sprites.sprite["ghostboss"])
        {
            Name = "Ghost Greg",
            Location = new int[2] { 10, 130 },
            Attack = 25,
            Defence = 3,
            Health = 50,
            IsBoss = true,
            Music = @"\TBQuestMusic\Spooky Forest\ghosts of dreams_2.mp3",
            Level = 50,
            Gold = 200,
            MaxHealth = 50
        };

        public static Enemy spiderboss = new Enemy(Sprites.sprite["spiderboss"])
        {
            Name = "Spider Greg",
            Location = new int[2] { 4, 130 },
            Attack = 15,
            Defence = 3,
            Health = 50,
            IsBoss = true,
            Music = @"\TBQuestMusic\Spider Battle\threat.mp3",
            Color = ConsoleColor.Red,
            Level = 20,
            Gold = 100,
            MaxHealth = 50
        };
    }
}
