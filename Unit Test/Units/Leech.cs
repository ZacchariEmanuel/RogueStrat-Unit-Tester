using System.Collections.Generic;
using Unit_Test.Abilities;

namespace Unit_Test.Units
{
    class Leech : DefaultUnit
    {
        public Leech():base() {
            name = "Leech";
            Attack = 1;
            Health = 3;
            Abilities = new List<Ability> {
                new Leeching(this),
                new Bleed(1,this)
            };
        }
        private class Leeching : Ability
        {
            public Leeching(Unit attachedUnit) : base("Leeching", "Deathwatch - Gain 1 health", attachedUnit)
            {
                IsEvergreenMechanic = false;
            }
            public override void OnAnotherUnitsDeath()
            {
                attachedUnit.Health += 1;
            }
        }
    }
}
