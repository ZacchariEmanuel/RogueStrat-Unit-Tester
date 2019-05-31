using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Ability_Bleeding : StackAbility
    {
        public Ability_Bleeding(int count, Unit attachedUnit) : base(count, "Bleeding","Whenever this unit is damaged, take an additional X damage",attachedUnit)
        {
            IsEvergreenMechanic = true;
        }
        public override void AfterRecieveDamage(Unit attacker, int damage)
        {
            if (damage > 0)
                attachedUnit.Health.CurrentValue -= count;
        }
    }
}
