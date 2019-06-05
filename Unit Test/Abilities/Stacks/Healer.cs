using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class Healer : StackAbility
    {
        public Healer(int count, Unit attachedUnit) : base(count, "Healer", "Heals friendly characters during combat",attachedUnit)
        {
            IsEvergreenMechanic = true;
        }
        public override void BeforeCombatStep()
        {
            if (attachedUnit.AlliesInAttackRange.Count == 0)
            {
                ref int targetHealth = ref attachedUnit.owner == Owner.player ? ref attachedUnit.playerDataReference.player_health : ref attachedUnit.playerDataReference.enemy_health;
                targetHealth += count;
            }
            else
            {
                foreach (Unit ally in attachedUnit.AlliesInAttackRange)
                    ally.Health.CurrentValue += 1;
            }
        }
    }
}
