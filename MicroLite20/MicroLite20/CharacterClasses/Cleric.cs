namespace MicroLite20.Classes {
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
