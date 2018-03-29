using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public class Map
    {
        private List<Stage> universe;

        public List<Stage> Universe
        {
            get { return universe; }
            set { universe = value; }
        }


        public Map()
        {
            universe = new List<Stage>();
            universe.Add(
                new Stage(
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "        \n" +
                    "   █    \n" +
                    "   █ █  \n" +
                    "  █  █  \n" +
                    "  █ █   \n" +
                    "  █ █  █\n" +
                    " █ █  █ \n" +
                    " █ █  █ \n" +
                    " █ █ █  \n" +
                    " █ █ █  \n" +
                    "█ █  █  \n" +
                    "█ █ █   \n" +
                    "█ █ █   \n" +
                    "█ █ █   \n" +
                    "████████\n" +
                    "█ ██ ██ \n" +
                    "██ ██ ██\n" +
                    "████████\n",
                    new List<Object>()
                    {
                        new Object(100, 10, 15, 10,
                            new List<List<string>>() {
                                new List<string>() {
                                    "    █   \n" +
                                    "   █ █  \n" +
                                    "  █ █ █ \n" +
                                    " █ █  █ \n" +
                                    " █    █ \n" +
                                    "  █  █  \n" +
                                    " ██████ \n" +
                                    "  █  █  \n" +
                                    "   ██   \n"
                                },
                                new List<string>() {
                                    "   █    \n" +
                                    "  █ █   \n" +
                                    " █ █ █  \n" +
                                    " █  █ █ \n" +
                                    " █    █ \n" +
                                    "  █  █  \n" +
                                    " ██████ \n" +
                                    "  █  █  \n" +
                                    "   ██   \n"
                                }
                            }
                        ),
                        new Object(20, 10, 15, 10,
                            new List<List<string>>() {
                                new List<string>() {
                                    "   █  \n" +
                                    "  █ █ \n" +
                                    " █ █ █\n" +
                                    "█ █  █\n" +
                                    "█    █\n" +
                                    " █  █ \n" +
                                    "██████\n" +
                                    " █  █ \n" +
                                    "  ██  \n"
                                },
                                new List<string>() {
                                    "  █   \n" +
                                    " █ █  \n" +
                                    "█ █ █ \n" +
                                    "█  █ █\n" +
                                    "█    █\n" +
                                    " █  █ \n" +
                                    "██████\n" +
                                    " █  █ \n" +
                                    "  ██  \n"
                                }
                            }
                        )
                    }
                )
            );

            universe.Add(Stages.ditherDungeon);

            universe.Add(Stages.lightDungeon);
        }
    }
}


                        //new Object(100, 10, 22, 9,
                        //    new List<List<string>>() {
                        //        new List<string>() {
                        //            "\0        \n" +
                        //            "\0   █    \n" +
                        //            "\0  █ █   \n" +
                        //            "\0 ███ █  \n" +
                        //            "\0██    █ \n" +
                        //            "\0 █   █  \n" +
                        //            "\0  █ █   \n" +
                        //            "\0███████ \n" +
                        //            "\0  ███   \n" +
                        //            "\0        \n"
                        //        }
                        //    }
                        //)