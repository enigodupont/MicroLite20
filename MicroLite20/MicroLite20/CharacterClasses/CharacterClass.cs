using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroLite20.Classes {
    abstract public class CharacterClass {

        //Armor Shield booleans
        public bool canUseShields = false;
        public bool canUseLArmor = false;
        public bool canUseMArmor = false;
        public bool canUseHArmor = false;

        //Skill Bonuses
        public int physicalBonus = 0;
        public int subterfugeBonus = 0;
        public int knowledgeBonus = 0;
        public int communicationBonus = 0;

        //Attack and Damage roll bonus
        public int damageBonus = 0;
        public int attackBonus = 0;

        //Spell types
        public bool canCastArcane = false;
        public bool canCastDivine = false;

        public abstract void levelUp(int level);


    }
}
