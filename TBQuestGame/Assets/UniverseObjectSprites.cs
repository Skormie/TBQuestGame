using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame
{
    public static class UniverseObjectSprites
    {
        public static Dictionary<string, List<string>> sprite = new Dictionary<string, List<string>>()
        {
            { "torch", new List<string>() {
                            "    █   \n" +
                            "   █ █  \n" +
                            "  █ █ █ \n" +
                            " █ █  █ \n" +
                            " █    █ \n" +
                            "  █  █  \n" +
                            " ██████ \n" +
                            "  █  █  \n" +
                            "   ██   \n"
                        ,
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
            },

            { "lightdungeon", new List<string>() {
                     "        ██    ████    ██\n" +
                     " ██████ █      ██      █\n" +
                     "        █      ██      █\n" +
                     " ██████ ██    ████    ██\n" +
                     "          ████    ████  \n" +
                     " █ ██ █    ██      ██   \n" +
                     " █ ██ █    ██      ██   \n" +
                     "  ████    ████    ████  \n" +
                     "   ██   ██    ████    ██\n" +
                     "  █  █  █      ██      █\n" +
                     "   ██   █      ██      █\n" +
                     "  ████  ██    ████    ██\n" +
                     "   ██     ████    ████  \n" +
                     "  █  █     ██      ██   \n" +
                     "   ██      ██      ██   \n" +
                     "  ████    ████    ████  \n" +
                     "   ██   ██    ████    ██\n" +
                     "  █  █  █      ██      █\n" +
                     "   ██   █      ██      █\n" +
                     "  ████  ██    ████    ██\n" +
                     "   ██     ████    ████  \n" +
                     "  █  █     ██      ██   \n" +
                     "   ██      ██      ██   \n" +
                     "  ████    ████    ████  \n" +
                     "   ██   ██    ████    ██\n" +
                     "  █  █  █      ██      █\n" +
                     "   ██   █      ██      █\n" +
                     "  ████  ██    ████    ██\n" +
                     "   ██     ████    ████  \n" +
                     "  █  █     ██      ██   \n" +
                     " █ ██ █    ██      ██   \n" +
                     " █ ██ █   ████    ████  \n" +
                     "████████████████████████\n" +
                     " ██  ██  ██  ██  ██  ██ \n" +
                     "  ██  ██  ██  ██  ██  ██\n" +
                     "█  ██  ██  ██  ██  ██  █\n"
                }
            },

            { "ditherdungeon", new List<string>() {
                    "▓▓▓▓▓▓                      \n" +
                    "       ▓       ▓       ▓    \n" +
                    "▓▓▓▓▓▓  ▓     ▓ ▓     ▓ ▓   \n" +
                    "         ▓ ▓     ▓ ▓     ▓  \n" +
                    "▓ ▓▓ ▓    ▓▓      ▓▓      ▓ \n" +
                    "▓ ▓▓ ▓     ▓       ▓        \n" +
                    " ▓▓▓▓    ▓▓▓▓    ▓▓▓      ▓ \n" +
                    "  ▓▓    ▓    ▓▓▓▓    ▓▓▓    \n" +
                    " ▓  ▓  ▓      ▓▓       ▓    \n" +
                    "  ▓▓                  ▓▓    \n" +
                    " ▓▓▓▓  ▓▓      ▓     ▓ ▓▓   \n" +
                    "  ▓▓      ▓   ▓ ▓  ▓▓    ▓  \n" +
                    " ▓  ▓     ▓  ▓ ▓ ▓ ▓      ▓ \n" +
                    "  ▓▓      ▓ ▓ ▓  ▓ ▓        \n" +
                    " ▓▓▓▓    ▓▓ ▓    ▓ ▓      ▓ \n" +
                    "  ▓▓    ▓    ▓  ▓    ▓▓▓    \n" +
                    " ▓  ▓  ▓    ▓▓▓▓▓▓     ▓    \n" +
                    "  ▓▓         ▓  ▓     ▓▓    \n" +
                    " ▓▓▓▓  ▓▓     ▓▓     ▓ ▓▓   \n" +
                    "  ▓▓      ▓▓▓    ▓▓▓▓    ▓  \n" +
                    " ▓  ▓     ▓▓      ▓▓      ▓ \n" +
                    "  ▓▓      ▓▓      ▓▓        \n" +
                    " ▓▓▓▓    ▓▓▓▓    ▓▓▓      ▓ \n" +
                    "  ▓▓    ▓    ▓▓▓▓    ▓▓▓    \n" +
                    " ▓  ▓  ▓      ▓        ▓    \n" +
                    "  ▓▓          ▓▓      ▓▓    \n" +
                    " ▓▓▓▓   ▓     ▓ ▓     ▓ ▓   \n" +
                    "  ▓▓     ▓ ▓     ▓ ▓     ▓  \n" +
                    " ▓  ▓     ▓       ▓       ▓ \n" +
                    "▓ ▓▓ ▓                      \n" +
                    "▓ ▓▓ ▓                      \n" +
                    "   ▓ ▓ ▓ ▓▓▓▓▓▓▓▓▓▓▓▓▓ ▓ ▓ ▓\n" +
                    "    ▓   ▓   ▓▓  ▓▓  ▓   ▓   \n" +
                    "         ▓▓  ▓▓  ▓▓  ▓      \n" +
                    "      ▓   ▓▓  ▓▓  ▓   ▓     "
                }
            }

        };
    }
}