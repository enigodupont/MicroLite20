using MicroLite20.Classes;
using MicroLite20.Utility;

namespace MicroLite20 {

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
        public string playerRace = "Human";
        public playerClass myClass = null;

        public PlayerData(int str, int dex, int mind, string race) {
            STR = str;
            DEX = dex;
            MIND = mind;

            HP = STR + (DiceRoller.rollD6());

            switch (race) {
                case "Human":
                    break;
                case "Elf":
                    break;
                case "Dwarf":
                    break;
                case "Halfling":
                    break;
                default:
                    break;
            }
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
