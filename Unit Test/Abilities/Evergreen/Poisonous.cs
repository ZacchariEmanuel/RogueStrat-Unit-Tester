using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class Poisonous : StackAbility
    {
        public Poisonous(int count, Unit attachedUnit) : base(count,"Poisonous", "Applies poison to enemies it attacks", attachedUnit) {
            IsEvergreenMechanic = true;
        }
        public override void BeforeDamageDealt_ToUnit(Unit target, ref int damage)
        {
            target.AddAbility(new Poisoned(count, target));
        }
    }
}
