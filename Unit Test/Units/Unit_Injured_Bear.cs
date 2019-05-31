using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Unit_Injured_Bear : DefaultUnit
    {
        public Unit_Injured_Bear():base() {
            name = "Injured Bear";
            Attack = 4;
            Health = 8;
            Abilities = new List<Ability>() { new Ability_Bleeding(2,this) };
        }
    }
}
