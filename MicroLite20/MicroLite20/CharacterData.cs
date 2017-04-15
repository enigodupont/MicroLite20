using MicroLite20.Classes;
using MicroLite20.Utility;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MicroLite20 {
    public class CharacterData {
        public string characterName { get; set; }

        //Attributes
        public int HP  { get; set; }
        public int STR { get; set; }
        public int STRMOD {
            get { return (STR - 10) / 2; }
        }
        public int DEX { get; set; }
        public int DEXMOD {
            get { return (DEX - 10) / 2; }
        }
        public int MIND { get; set; }
        public int MINDMOD {
            get { return (MIND - 10) / 2; }
        }

        //Skills
        public int attackRoll { get; set; }
        public int damageRoll { get; set; }
        public int skillRoll { get; set; }

        public int physical { get; set; }
        public int subterfuge { get; set; }
        public int knowledge { get; set; }
        public int communication { get; set; }

        public int exp { get; set; }
        public int myLevel { get; set; }
        public string charRace { get; set; }
        public string characterClassString { get; set; }
        public CharacterClass characterClass = null;

        public int attributePoints = 0;

        public CharacterData() { }

        public CharacterData(int str, int dex, int mind, string chClass, string race, string charName) {
            STR = str;
            DEX = dex;
            MIND = mind;

            HP = STR + (DiceRoller.rollD6());
            characterClassString = chClass;
            charRace = race;
            characterName = charName;

            switch (characterClassString) {
                case "Fighter":
                    characterClass = new Fighter();
                    break;

                case "Magi":
                    characterClass = new Magi();
                    break;

                case "Rogue":
                    characterClass = new Rogue();
                    break;

                case "Cleric":
                    characterClass = new Cleric();
                    break;
            }

            switch (charRace) {
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

            if(myLevel % 3 == 0) {
                ++attributePoints;
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

            characterClass.levelUp(myLevel);
        }

        public int getPhysical() {
            return characterClass.physicalBonus + physical;
        }

        public int getSubterfuge() {
            return characterClass.subterfugeBonus + subterfuge;
        }

        public int getKnowledge() {
            return characterClass.knowledgeBonus + knowledge;
        }

        public int getCommunication() {
            return characterClass.communicationBonus + communication;
        }

        public string serialize() {

            JsonSerializerSettings settings = new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.SerializeObject(this,settings);
            
        }
    }
}
