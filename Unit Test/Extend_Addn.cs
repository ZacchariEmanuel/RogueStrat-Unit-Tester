using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_ExtensionMethods
{
    public static class Extend_Addn
    {
        public static T RemoveRDM<T>(this List<T> list, Random seed)
        {
            int n = seed.Next(0, list.Count);
            T item = list[n];
            list.RemoveAt(n);
            return item;
        }
    }
}
