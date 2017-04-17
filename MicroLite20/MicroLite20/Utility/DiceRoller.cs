using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroLite20.Utility {
    static class DiceRoller {
        private static Random randGenerator = new Random();
        
        public static int rollD6() {
            //Returns a non-negative number so > 0 less than max provided (7) so 1-6
            return randGenerator.Next(1,7);
        }

        public static int rollD10() {
            //Returns a non-negative number so > 0 less than max provided (11) so 1-10
            return randGenerator.Next(1,11);
        }

        public static int rollD20() {
            //Returns a non-negative number so > 0 less than max provided (21) so 1-20
            return randGenerator.Next(1,21);
        }
    }
}
