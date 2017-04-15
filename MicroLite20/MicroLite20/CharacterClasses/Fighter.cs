using System.Xml.Serialization;

namespace MicroLite20.Classes {
    [XmlInclude(typeof(CharacterClass))]
    public class Fighter : CharacterClass {

        public Fighter() {
            canUseShields = true;
            canUseLArmor = true;
            canUseMArmor = true;
            canUseHArmor = true;

            physicalBonus = 3;

            attackBonus = 1;
            damageBonus = 1;
        }

        public override void levelUp(int level) {
            if((level % 5 == 0)) {
                ++physicalBonus;
                ++attackBonus;
                ++damageBonus;
            }
        }
    }
}
