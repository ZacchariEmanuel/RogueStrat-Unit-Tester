using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class QuickStrike : Ability
    {
        public QuickStrike(Unit attachedUnit) : base("Quick-strike", "Attacks immediately after it is played", attachedUnit)
        {
            IsEvergreenMechanic = true;
        }

        public override void OnPlace()
        {
            attachedUnit.PerformCombat();
        }
    }
}
