using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public interface ITypeFactory
    {
        Type GetTypeByName(string name);
    }
}
