using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class Unyielding : Ability
    {
        public Unyielding(Unit attachedUnit) : base("Unyielding", "Cannot be Outnumbered", attachedUnit) {
            IsEvergreenMechanic = true;
        }
        public override void OnGetOutnumbered(ref bool isOutNumbered)
        {
            isOutNumbered = false;
        }
    }
}
