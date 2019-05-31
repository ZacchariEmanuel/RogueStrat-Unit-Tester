using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    class Unit_Bear : DefaultUnit
    {
        
        public Unit_Bear():base() {
            name = "Bear";
            Attack = 4;
            Health = 8;
        }
    }
}
