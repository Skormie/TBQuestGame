using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Area
    {

        static public List<Stage> emptyArea = new List<Stage>();

        static public List<Stage> shop = new List<Stage>
        {
                TBQuestGame.Universe.shop
        };

        static public List<Stage> innerCastle = new List<Stage>
        {
                TBQuestGame.Universe.innerCastle
        };

        static public List<Stage> innerHouse = new List<Stage>
        {
                TBQuestGame.Universe.innerHouse
        };

        static public List<Stage> innerHouse2 = new List<Stage>
        {
                TBQuestGame.Universe.innerHouse2
        };

        static public List<Stage> firstfieldArea = new List<Stage>
        {
                TBQuestGame.Universe.field,
                Universe.lightDungeon,
                new Stage(Universe.emptyField),
                new Stage(Universe.emptyField),
                Universe.fieldFence,
                Universe.fencedField
        };

        static public List<Stage> firstTownArea = new List<Stage>
        {
                Universe.townTown,
                Universe.townTavern,
                Universe.townItemAndForge
        };

        static public List<Stage> secondfieldArea = new List<Stage>
        {
                Universe.fenceField,
                new Stage(Universe.emptyField),
                new Stage(Universe.reverseField),
                Universe.fieldForest
        };

        static public List<Stage> forestArea = new List<Stage>
        {
                Universe.forestStraight,
                new Stage(Universe.forestStraight, false),
                new Stage(Universe.forestStraight, false),
                Universe.forestStraightField,
                Universe.caveEntrance
        };

        static public List<Stage> caveArea = new List<Stage>
        {
                Universe.caveLightEnter,
                new Stage(Universe.caveLight),
                Universe.caveLightDark,
                new Stage(Universe.caveDark),
                new Stage(Universe.caveDark, Monsters.spiderboss),
                Universe.caveDarkLight,
                Universe.caveLightExit,
        };

        static public List<Stage> plainArea = new List<Stage>
        {
                Universe.caveExitPlain,
                Universe.plains,
                new Stage(Universe.plains),
                Universe.plainsDeadWoods
        };

        static public List<Stage> deadWoodsArea = new List<Stage>
        {
                new Stage(Universe.deadWoods, false),
                Universe.deadWoods,
                Universe.thickDeadWoods, //Boss Area
                new Stage(Universe.deadWoods, false),
                Universe.deadWoodsPlains
        };

        static public List<Stage> town2Area = new List<Stage>
        {
                Universe.townSecondEnterance,
                Universe.townSecondTavern,
                Universe.townSecond,
                Universe.townSecondForge,
                Universe.townSecondCastle
        };

        static public List<Stage> dungeonArea = new List<Stage>
        {
                Universe.lightDungeon,
                Universe.dungeonPillers,
                Universe.dungeonPillersDoor,
                Universe.ditherDungeon,
                Universe.darkDitherDungeon,
                Universe.finalBossFight
        };

        static public Dictionary<string, List<Stage>> mapLookup = new Dictionary<string, List<Stage>>()
        {
            { "", emptyArea },
            { "Albert's Shop", shop },
            { "Unknown Field", firstfieldArea },
            { "Amatsu", firstTownArea },
            { "Amatsu Field", secondfieldArea },
            { "Taltree", forestArea },
            { "Mountain Pass", caveArea },
            { "Plains", plainArea },
            { "Dead Woods", deadWoodsArea },
            { "Prontera", town2Area },
            { "Inner Castle", innerCastle },
            { "Castle Dungeon", dungeonArea }
        };

        static public List<Stage>[] maps = new List<Stage>[]
        {
            emptyArea,
            shop,
            emptyArea,
            firstfieldArea,
            firstTownArea,
            secondfieldArea,
            forestArea,
            emptyArea,
            caveArea,
            emptyArea,
            plainArea,
            deadWoodsArea,
            town2Area,
            emptyArea,
            dungeonArea,
            emptyArea,
            innerCastle,
            emptyArea,
            innerHouse,
            emptyArea,
            innerHouse2
        };
    }
}