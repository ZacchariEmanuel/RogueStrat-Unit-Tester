using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    static class AdvMath
    {
        static public int DivideRoundUp(int numerator, int denominator) {
            return (numerator / denominator) + (numerator % 2);
        }
    }
}
