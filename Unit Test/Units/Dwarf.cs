using System.Collections.Generic;
using Unit_Test.Abilities;

namespace Unit_Test.Units
{
    class Dwarf : DefaultUnit
    {
        
        public Dwarf():base() {
            name = "Dwarf";
            Attack = 2;
            Health = 6;
            Abilities = new List<Ability>() {
                new Unyielding(this),
                new Vigilant(this)
            };
        }
    }
}
