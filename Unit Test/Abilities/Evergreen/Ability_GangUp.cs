using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Ability_GangUp : Ability
    {
        public Ability_GangUp(Unit attachedUnit) : base("Gang Up", "Deals double damage to outnumbered enemies", attachedUnit) {
            IsEvergreenMechanic = true;
        }
        public override void BeforeDamageDealt_ToUnit(Unit target, ref int damage)
        {
            if (target.isOutnumbered)
                damage *= 2;
        }
    }
}
