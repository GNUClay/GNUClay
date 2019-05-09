using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public static class TypeFactoryForSystemTypes
    {
        public static Type GetTypeByName(string name)
        {
            switch(name)
            {
                case "System.Collections.Generic.Dictionary`2[[System.Int32],[System.String]]":
                    return typeof(Dictionary<int, string>);

                case "System.Collections.Generic.Dictionary`2[[System.Int32],[System.Int32]]":
                    return typeof(Dictionary<int, int>);

                case "System.Collections.Generic.List`1[[System.String]]":
                    return typeof(List<string>);

                case "System.Int32[]":
                    return typeof(int[]);

                default:
                    return null;
            }
        }
    }
}
