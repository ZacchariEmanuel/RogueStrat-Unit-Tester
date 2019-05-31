using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Unit_Eviscerating_Bear : DefaultUnit
    {
        public Unit_Eviscerating_Bear() : base() {
            name = "Eviscerating Bear";
            Attack = 4;
            Health = 8;
            Abilities = new List<Ability>() {
                new ETBT(this)
            };
        }
        private class ETBT : Ability {
            public ETBT(Unit attachedUnit) : base("Eviscerate", "When you play this unit, give adjacent enemies Bleeding 2", attachedUnit)
            {
                IsEvergreenMechanic = false;
            }
            public override void OnPlace()
            {
                foreach (Unit target in attachedUnit.EnemiesInAttackRange)
                    target.AddAbility(new Ability_Bleeding(2,target));
            }
        }
    }
}
