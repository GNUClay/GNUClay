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
        public int TypeKey = 0;
        public Dictionary<int, List<IGnuClayScriptFunctor>> SystemMethods = new Dictionary<int, List<IGnuClayScriptFunctor>>();
        public Dictionary<int, List<IGnuClayScriptFunctor>> ExternalMethods = new Dictionary<int, List<IGnuClayScriptFunctor>>();
        public Dictionary<int, List<IGnuClayAbstractProperty>> SystemProperties = new Dictionary<int, List<IGnuClayAbstractProperty>>();
    }
}
