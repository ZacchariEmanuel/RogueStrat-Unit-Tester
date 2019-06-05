using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class GangUp : Ability
    {
        public GangUp(Unit attachedUnit) : base("Gang Up", "Deals double damage to outnumbered enemies", attachedUnit) {
            IsEvergreenMechanic = true;
        }
        public override void BeforeDamageDealt_ToUnit(Unit target, ref int damage)
        {
            if (target.isOutnumbered)
                damage *= 2;
        }
    }
}
