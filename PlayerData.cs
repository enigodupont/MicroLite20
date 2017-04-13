using Microlite20.Classes;
using Microlite20.Utility;

namespace Microlite20 {

    class PlayerData {
        public string characterName = "Nanashi";

        //Attributes
        public int HP = 0;
        public int STR = 0;
        public int DEX = 0;
        public int MIND = 0;

        //Skills
        public int attackRoll = 0;
        public int damageRoll = 0;
        public int physical = 0;
        public int subterfuge = 0;
        public int knowledge = 0;
        public int communication = 0;

        public int exp = 0;
        public int myLevel = 1;
        //public playerRace;
        public playerClass myClass = null;

        public PlayerData(int str, int dex, int mind) {
            STR = str;
            DEX = dex;
            MIND = mind;

            HP = STR + (DiceRoller.rollD6());
        }

        public void applyEXP(int newEXP) {
            exp += newEXP;

            if(exp >= (10*myLevel)) {
                exp -= (10 * myLevel);
                levelUp();
            }


        }

        public void levelUp() {
            ++myLevel;

            if((myLevel % 3) == 0) {
                //TODO: Message box prompt to upgrade WILL/STR/MIND
            }

            // Add 1d6 to hitpoints
            HP += DiceRoller.rollD6();

            //Upgrade Attack
            ++attackRoll;

            //Upgrade skills by 1
            ++physical;
            ++subterfuge;
            ++knowledge;
            ++communication;

            myClass.levelUp(myLevel);
        }
    }
}
