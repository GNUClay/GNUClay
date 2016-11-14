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
        public Dictionary<int, List<IGnuClayScriptFunctor>> SystemMethods = new Dictionary<int, List<IGnuClayScriptFunctor>>();
    }
}
