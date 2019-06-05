using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class Burning : StackAbility
    {
        public Burning(int count, Unit attachedUnit) : base(count, "Burning", "At the end of each turn, this unit takes X damage. Lessens each turn.",attachedUnit)
        { 
            IsEvergreenMechanic = true;
        }
        public override void OnEndOfTurn()
        {
            attachedUnit.Health.CurrentValue -= count;
            if(count > 0)
                count--;
        }
    }
}
