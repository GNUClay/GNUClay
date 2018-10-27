using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib
{
    public static class DictionaryHelper
    {
        public static bool IsEmpty<K, T>(this IDictionary<K, T> dict)
        {
            if (dict == null)
            {
                return true;
            }

            if (dict.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
