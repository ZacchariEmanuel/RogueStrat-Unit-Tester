using System.Collections.Generic;
using Unit_Test.Abilities;

namespace Unit_Test.Units
{
    class Imp : DefaultUnit
    {
        
        public Imp():base() {
            name = "Imp";
            Attack = 3;
            Health = 3;
            Abilities = new List<Ability>() {
                new GangUp(this)
            };
        }
    }
}
