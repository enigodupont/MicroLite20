using System.Xml.Serialization;

namespace MicroLite20.Classes {
    [XmlInclude(typeof(CharacterClass))]
    public class Cleric : CharacterClass {

        public Cleric() {
            communicationBonus = 3;
            canUseLArmor = true;
            canUseMArmor = true;
            canCastDivine = true;
        }

        public override void levelUp(int level) {
            //Do Nothing
        }
    }
}
