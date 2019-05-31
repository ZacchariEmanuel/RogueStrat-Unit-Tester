using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    public class UnitVariable<T>
    {
        public readonly T BaseValue;
        public T CurrentValue;
        public UnitVariable(T BaseValue)
        {
            this.BaseValue = BaseValue;
            CurrentValue = BaseValue;
        }

        public void Reset()
        {
            CurrentValue = BaseValue;
        }
        public static implicit operator T(UnitVariable<T> unitProperty)
        {
            return unitProperty.CurrentValue;
        }

        public static implicit operator UnitVariable<T>(T propertValue)
        {
            return new UnitVariable<T>(propertValue);
        }
    }
}
