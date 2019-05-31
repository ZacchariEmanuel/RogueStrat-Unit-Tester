using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Unit_Watchful_Bear : DefaultUnit
    {
        public Unit_Watchful_Bear():base() {
            name = "Watchful Bear";
            Attack = 4;
            Health = 10;
            Abilities = new List<Ability>() {
                new Ability_Vigilant(this)
            };
        }
    }
}
