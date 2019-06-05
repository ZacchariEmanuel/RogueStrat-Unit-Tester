using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class Agile : Ability
    {
        public Agile(Unit attachedUnit) : base("Agile", "Takes half damage, unless it is outnumbered", attachedUnit) {
            IsEvergreenMechanic = true;
        }
        public override void BeforeRecieveDamage(Unit attacker, ref int damage)
        {
            if(!attachedUnit.isOutnumbered)
                damage = AdvMath.DivideRoundUp(damage,2);
        }
    }
}
