using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Area
    {

        static public List<Stage> firstfieldArea = new List<Stage>
        {
                TBQuestGame.Universe.field,
                Universe.lightDungeon,
                new Stage(Universe.emptyField),
                new Stage(Universe.emptyField),
                new Stage(Universe.emptyField),
                new Stage(Universe.emptyField)
        };

        static public List<Stage> firstTownArea = new List<Stage>
        {
                TBQuestGame.Universe.townTown,
                TBQuestGame.Universe.townTavern,
                TBQuestGame.Universe.townItemAndForge
        };

        static public List<Stage> secondfieldArea = new List<Stage>
        {
                TBQuestGame.Universe.field,
                new Stage(Universe.emptyField),
                new Stage(Universe.emptyField),
                new Stage(Universe.emptyField),
                new Stage(Universe.emptyField),
                Universe.fieldForest
        };

        static public List<Stage> forestArea = new List<Stage>
        {
                TBQuestGame.Universe.forestStraight,
                new Stage(Universe.forestStraight),
                new Stage(Universe.forestStraight),
                Universe.forestStraightField
        };

        static public List<Stage>[] maps = new List<Stage>[] { firstfieldArea, firstTownArea, secondfieldArea, forestArea };
    }
}