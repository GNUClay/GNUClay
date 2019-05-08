using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public class MapTypeFactory: ITypeFactory
    {
        public MapTypeFactory(Func<string, Type> func)
        {
            mFunc = func;
        }

        private readonly Func<string, Type> mFunc;

        public Type GetTypeByName(string name)
        {
            return mFunc(name);
        }
    }
}
