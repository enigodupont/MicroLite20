using MicroLite20.Classes;
using MicroLite20.Utility;

namespace MicroLite20 {

    public class CharacterData {
        public string characterName = "Nanashi";

        //Attributes
        public int HP = 0;
        public int STR = 0;
        public int DEX = 0;
        public int MIND = 0;

        //Skills
        public int attackRoll = 0;
        public int damageRoll = 0;
        public int skillRoll = 0;
        public int physical = 0;
        public int subterfuge = 0;
        public int knowledge = 0;
        public int communication = 0;

        public int exp = 0;
        public int myLevel = 1;
        public string playerRace = "Human";
        public CharacterClass myClass = null;

        public CharacterData(int str, int dex, int mind, string charClass, string race, string charName) {
            STR = str;
            DEX = dex;
            MIND = mind;

            HP = STR + (DiceRoller.rollD6());
            playerRace = race;
            characterName = charName;

            switch (charClass) {
                case "Fighter":
                    myClass = new Fighter();
                    break;

                case "Magi":
                    myClass = new Magi();
                    break;

                case "Rogue":
                    myClass = new Rogue();
                    break;

                case "Cleric":
                    myClass = new Cleric();
                    break;
            }

            switch (playerRace) {
                case "Human":
                    ++skillRoll;
                    break;
                case "Elf":
                    MIND += 2;
                    break;
                case "Dwarf":
                    STR += 2;
                    break;
                case "Halfling":
                    DEX += 2;
                    break;
                default:
                    break;
            }
        }

        public void applyEXP(int newEXP) {
            exp += newEXP;

            while(exp >= (10*myLevel)) {
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
