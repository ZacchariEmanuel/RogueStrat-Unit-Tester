using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class Bleed : StackAbility
    {
        public Bleed(int count, Unit attachedUnit) : base(count, "Bleed", "Whenever this unit attacks, add X bleed stacks to the targets",attachedUnit)
        {
            IsEvergreenMechanic = true;
        }
        public override void AfterDamageDealt_ToUnit(Unit target, int damage)
        {
            target.AddAbility(new Bleeding(count, target));
        }
    }
}
