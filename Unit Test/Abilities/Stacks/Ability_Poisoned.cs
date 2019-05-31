using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Ability_Poisoned : StackAbility
    {
        public Ability_Poisoned(int count, Unit attachedUnit) : base(count, "Poisoned", "At the end of each turn, this unit takes X damage. Lessens each turn.",attachedUnit)
        {
            IsEvergreenMechanic = true;
        }
        public override void OnEndOfTurn(){
            attachedUnit.Health.CurrentValue -= count;
        }
    }
}
