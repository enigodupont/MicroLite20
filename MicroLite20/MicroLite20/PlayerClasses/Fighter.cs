namespace MicroLite20.Classes {
    class Fighter : playerClass {

        Fighter() {
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
