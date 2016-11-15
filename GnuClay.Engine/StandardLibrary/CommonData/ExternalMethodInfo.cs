using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class ExternalParameterInfo
    {
        public int NameKey { get; set; }
        public int ParameterType { get; set; }
        public bool HasDefaultValue { get; set; }
        public object DefaultValue { get; set; }
    }

    public class ExternalMethodInfo
    {
        public int HolderKey { get; set; }
        public int MethodKey { get; set; }
        public List<ExternalParameterInfo> Parameters = new List<ExternalParameterInfo>();
    }
}
