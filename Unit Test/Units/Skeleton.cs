using System.Collections.Generic;
using Unit_Test.Abilities;

namespace Unit_Test.Units
{
    class Skeleton : DefaultUnit
    {
        
        public Skeleton():base() {
            name = "Skeleton";
            Attack = 2;
            Health = 5;
            Abilities = new List<Ability>() {
                new Unyielding(this)
            };
        }
    }
}
