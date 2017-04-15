using System.Xml.Serialization;

namespace MicroLite20.Classes {
    [XmlInclude(typeof(CharacterClass))]
    public class Rogue : CharacterClass {

        public Rogue() {
            canUseLArmor = true;

            subterfugeBonus = 3;
        }

        public override void levelUp(int level) {
            //Do Nothing
        }
    }
}
