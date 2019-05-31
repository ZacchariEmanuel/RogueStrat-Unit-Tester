using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Unit_FrenzyRat : DefaultUnit
    {
        
        public Unit_FrenzyRat():base() {
            name = "Frenzy Rat";
            Attack = 1;
            Health = 3;
            Abilities = new List<Ability>() {
                new Ability_Unyielding(this),
                new Ability_GangUp(this)
            };
        }
    }
}
