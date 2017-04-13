using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microlite20.Utility {
    static class DiceRoller {
        private static Random randGenerator = new Random();
        
        public static int rollD6() {
            //Returns a non-negative number so > 0 less than max provided (7) so 0-6
            return randGenerator.Next(7);
        }

        public static int rollD10() {
            //Returns a non-negative number so > 0 less than max provided (11) so 0-10
            return randGenerator.Next(11);
        }

        public static int rollD20() {
            //Returns a non-negative number so > 0 less than max provided (21) so 0-20
            return randGenerator.Next(21);
        }
    }
}
