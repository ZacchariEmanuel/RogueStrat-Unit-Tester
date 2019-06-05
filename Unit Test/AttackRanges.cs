using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    static class AttackRanges
    {
        public static Func<Unit, List<Unit>> DefaultAttackRange
        {
            get
            {
                return new Func<Unit, List<Unit>>(unit =>
                {
                    List<Unit> t = unit.tileReference.parentMap.UnitsOnMap.Where(x =>
                    {
                        int delta = Math.Abs(unit.xPos - x.xPos) + Math.Abs(unit.yPos - x.yPos);
                        return delta == 1;
                    }).ToList();
                    return t;
                });
            }
        }

        public static Func<Unit, List<Unit>> VigilantAttackRange
        {
            get
            {
                return new Func<Unit, List<Unit>>(unit =>
                {
                    List<Unit> t = unit.tileReference.parentMap.UnitsOnMap.Where(x =>
                    {
                        int deltax = Math.Abs(unit.xPos - x.xPos);
                        int deltay = Math.Abs(unit.yPos - x.yPos);
                        bool delta_valid = (deltax == 0 || deltax == 1) && (deltay == 0 || deltay == 1) && (deltax + deltay == 1 || deltax + deltay == 2);
                        return delta_valid;
                    }).ToList();
                    return t;
                });
            }
        }
    }
}
