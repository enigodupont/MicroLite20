namespace MicroLite20.Classes {
    class Cleric : playerClass {

        Cleric() {
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
