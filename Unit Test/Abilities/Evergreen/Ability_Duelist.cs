using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Ability_Duelist : Ability
    {
        public Ability_Duelist(Unit attachedUnit) : base("Duelist", "Deals double damage if not outnumbered", attachedUnit) {
            IsEvergreenMechanic = true;
        }
        public override void BeforeDamageDealt(ref int damage)
        {
            if (!attachedUnit.isOutnumbered)
                damage *= 2;
        }
    }
}
