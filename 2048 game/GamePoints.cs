using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_game
{
    static public class GamePoints
    {
        private static int points = 0;

        public static int getPoints()
        {
            return points;
        }
        public static void resetPoints()
        {
            points = 0;
        }

        public static void updatePoints(int p)
        {
            points = points + p;
        }
    }
}
