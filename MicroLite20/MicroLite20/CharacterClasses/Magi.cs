using System.Xml.Serialization;

namespace MicroLite20.Classes {
    [XmlInclude(typeof(CharacterClass))]
    public class Magi : CharacterClass {

        public Magi() {
            knowledgeBonus = 3;
            canCastArcane = true;
        }

        public override void levelUp(int level) {
            //Do Nothing
        }
    }
}
