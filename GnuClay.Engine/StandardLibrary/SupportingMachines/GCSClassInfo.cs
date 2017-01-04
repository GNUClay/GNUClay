using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class GCSClassInfo
    {
        public ulong TypeKey = 0;
        public Dictionary<ulong, List<IGnuClayScriptFunctor>> SystemMethods = new Dictionary<ulong, List<IGnuClayScriptFunctor>>();
        public Dictionary<ulong, List<IGnuClayScriptFunctor>> ExternalMethods = new Dictionary<ulong, List<IGnuClayScriptFunctor>>();
        public Dictionary<ulong, List<IGnuClayAbstractProperty>> SystemProperties = new Dictionary<ulong, List<IGnuClayAbstractProperty>>();
    }
}
