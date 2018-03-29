using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public static class Stages
    {
        public static Stage field = new Stage(
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
        );



        public static Stage lightDungeon = new Stage(
             UniverseObjectSprites.sprite["lightdungeon"][0],
             new List<Object>()
             {
                new Object(121, 10, 16, 11,
                    new List<List<string>>() {
                        new List<string>() {
                            "        \n" +
                            "    █   \n" +
                            "   █ █  \n" +
                            "  █ █ █ \n" +
                            " █ █  █ \n" +
                            " █    █ \n" +
                            "  █  █  \n" +
                            " ██████ \n" +
                            "  █  █  \n" +
                            "   ██   \n" +
                            "        \n"
                        },
                        new List<string>() {
                            "        \n" +
                            "   █    \n" +
                            "  █ █   \n" +
                            " █ █ █  \n" +
                            " █  █ █ \n" +
                            " █    █ \n" +
                            "  █  █  \n" +
                            " ██████ \n" +
                            "  █  █  \n" +
                            "   ██   \n" +
                            "        \n"
                        }
                    }
                ),
                new Object(25, 10, 16, 11,
                    new List<List<string>>() {
                        new List<string>() {
                            "        \n" +
                            "    █   \n" +
                            "   █ █  \n" +
                            "  █ █ █ \n" +
                            " █ █  █ \n" +
                            " █    █ \n" +
                            "  █  █  \n" +
                            " ██████ \n" +
                            "  █  █  \n" +
                            "   ██   \n" +
                            "        \n"
                        },
                        new List<string>() {
                            "        \n" +
                            "   █    \n" +
                            "  █ █   \n" +
                            " █ █ █  \n" +
                            " █  █ █ \n" +
                            " █    █ \n" +
                            "  █  █  \n" +
                            " ██████ \n" +
                            "  █  █  \n" +
                            "   ██   \n" +
                            "        \n"
                        }
                    }
                ),
                new Object(25, 25, 18, 7,
                    new List<List<string>>() {
                        new List<string>() {
                            "        \n" +
                            "        \n" +
                            "    █   \n" +
                            "   ███  \n" +
                            "    █   \n" +
                            "        \n" +
                            "        \n"
                        },
                        new List<string>() {
                            "        \n" +
                            "    █   \n" +
                            "        \n" +
                            " █  █  █\n" +
                            "        \n" +
                            "    █   \n" +
                            "        \n"
                        }
                    }, 3, "Shiny Thing"
                ),
                new Object(25, 25, 18, 7,
                    new List<List<string>>() {
                        new List<string>() {
                            "        \n" +
                            "        \n" +
                            "    █   \n" +
                            "   █0█  \n" +
                            "    █   \n" +
                            "        \n" +
                            "        \n"
                        },
                        new List<string>() {
                            "        \n" +
                            "    0   \n" +
                            "        \n" +
                            " 0  █  0\n" +
                            "        \n" +
                            "    0   \n" +
                            "        \n"
                        }
                    }, 3, "Shiny Thing 2"
                )
             }
         );

        public static Stage ditherDungeon = new Stage(
             UniverseObjectSprites.sprite["ditherdungeon"][0],
             new List<Object>()
             {
                        new Object(121, 10, 16, 11,
                            new List<List<string>>() {
                                new List<string>() {
                                    "        \n" +
                                    "    █   \n" +
                                    "   █ █  \n" +
                                    "  █ █ █ \n" +
                                    " █ █  █ \n" +
                                    " █    █ \n" +
                                    "  █  █  \n" +
                                    " ██████ \n" +
                                    "  █  █  \n" +
                                    "   ██   \n" +
                                    "        \n"
                                },
                                new List<string>() {
                                    "        \n" +
                                    "   █    \n" +
                                    "  █ █   \n" +
                                    " █ █ █  \n" +
                                    " █  █ █ \n" +
                                    " █    █ \n" +
                                    "  █  █  \n" +
                                    " ██████ \n" +
                                    "  █  █  \n" +
                                    "   ██   \n" +
                                    "        \n"
                                }
                            }
                        ),
                        new Object(25, 10, 16, 11,
                            new List<List<string>>() {
                                new List<string>() {
                                    "        \n" +
                                    "    █   \n" +
                                    "   █ █  \n" +
                                    "  █ █ █ \n" +
                                    " █ █  █ \n" +
                                    " █    █ \n" +
                                    "  █  █  \n" +
                                    " ██████ \n" +
                                    "  █  █  \n" +
                                    "   ██   \n" +
                                    "        \n"
                                },
                                new List<string>() {
                                    "        \n" +
                                    "   █    \n" +
                                    "  █ █   \n" +
                                    " █ █ █  \n" +
                                    " █  █ █ \n" +
                                    " █    █ \n" +
                                    "  █  █  \n" +
                                    " ██████ \n" +
                                    "  █  █  \n" +
                                    "   ██   \n" +
                                    "        \n"
                                }
                            }
                        ),
                        new Object(25, 25, 18, 7,
                            new List<List<string>>() {
                                new List<string>() {
                                    "        \n" +
                                    "        \n" +
                                    "    █   \n" +
                                    "   ███  \n" +
                                    "    █   \n" +
                                    "        \n" +
                                    "        \n"
                                },
                                new List<string>() {
                                    "        \n" +
                                    "    █   \n" +
                                    "        \n" +
                                    " █  █  █\n" +
                                    "        \n" +
                                    "    █   \n" +
                                    "        \n"
                                }
                            }, 3, "Shiny Thing"
                        ),
                        new Object(25, 25, 18, 7,
                            new List<List<string>>() {
                                new List<string>() {
                                    "        \n" +
                                    "        \n" +
                                    "    █   \n" +
                                    "   █0█  \n" +
                                    "    █   \n" +
                                    "        \n" +
                                    "        \n"
                                },
                                new List<string>() {
                                    "        \n" +
                                    "    0   \n" +
                                    "        \n" +
                                    " 0  █  0\n" +
                                    "        \n" +
                                    "    0   \n" +
                                    "        \n"
                                }
                            }, 3, "Shiny Thing 2"
                        )
             }
         );



    }
}
