using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class ExternalParameterInfo
    {
        public ulong NameKey { get; set; }
        public ulong ParameterType { get; set; }
        public bool HasDefaultValue { get; set; }
        public object DefaultValue { get; set; }
    }

    public class ExternalMethodInfo
    {
        public ulong HolderKey { get; set; }
        public ulong MethodKey { get; set; }
        public List<ExternalParameterInfo> Parameters = new List<ExternalParameterInfo>();
    }
}
