using System.Collections.Generic;

namespace Unit_Test.Units
{
    class Helpful_Spirit : DefaultUnit
    {
        public Helpful_Spirit() : base() {
            name = "Helpful Spirit";
            Attack = 1;
            Health = 6;
            Abilities = new List<Ability>() {
                new Abilities.Healer(1,this)
            };
        }
    }
}
