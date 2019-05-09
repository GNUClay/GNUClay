using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public class MapTypeFactory: ITypeFactory
    {
        public MapTypeFactory(Func<string, Type> func)
            : this(func, true)
        {
        }

        public MapTypeFactory(Func<string, Type> func, bool useFactoryForSystemTypes)
        {
            mFunc = func;
            mUseFactoryForSystemTypes = useFactoryForSystemTypes;
        }

        private readonly Func<string, Type> mFunc;
        private readonly bool mUseFactoryForSystemTypes;

        public Type GetTypeByName(string name)
        {
            if(mUseFactoryForSystemTypes)
            {
                var type = TypeFactoryForSystemTypes.GetTypeByName(name);

                if (type != null)
                {
                    return type;
                }
            }
      
            return mFunc(name);
        }
    }
}
