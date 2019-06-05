using System.Collections.Generic;
using Unit_Test.Abilities;

namespace Unit_Test.Units
{
    class Hawk : DefaultUnit
    {
        
        public Hawk():base() {
            name = "Hawk";
            Attack = 2;
            Health = 4;
            Abilities = new List<Ability>() {
                new QuickStrike(this),
                new Agile(this)
            };
        }
    }
}
