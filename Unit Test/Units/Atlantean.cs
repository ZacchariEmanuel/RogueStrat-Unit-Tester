using System;
using System.Collections.Generic;

namespace Unit_Test.Units
{
    class Atlantean : DefaultUnit
    {
        public Atlantean():base() {
            name = "Atlantean";
            Attack = 2;
            Health = 5;
            Abilities = new List<Ability> {
                new ETBT(this)
            };
        }
        private class ETBT : Ability
        {
            public ETBT(Unit attachedUnit) : base("Water Pump", "When placed next to a water tile, gain 1 attack and 1 health. When placed on a water tile, gain 2 attack and 2 health instead.", attachedUnit)
            {
                IsEvergreenMechanic = false;
            }
            public override void OnPlace()
            {
                if (attachedUnit.tileReference.isWater)
                {
                    attachedUnit.Attack += 2;
                    attachedUnit.Health += 2;

                } else if (attachedUnit.tileReference.parentMap.Tiles.Exists(tile => {
                    int delta = Math.Abs(tile.x - attachedUnit.tileReference.x) + Math.Abs(tile.y - attachedUnit.tileReference.y);
                    return tile.isWater && delta == 1;
                  })) {
                    attachedUnit.Attack += 1;
                    attachedUnit.Health += 1;
                }
            }
        }
    }
}
