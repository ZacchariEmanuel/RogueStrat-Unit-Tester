using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Ability_Vigilant : Ability
    {
            public Ability_Vigilant(Unit attachedUnit) : base("Vigilant","Also attacks diagonal tiles", attachedUnit) {
            IsEvergreenMechanic = true;
            }
            public override void OnLoad()
            {
                attachedUnit.AttackRangeFunction = AttackRanges.VigilantAttackRange;
            }
    }
}
