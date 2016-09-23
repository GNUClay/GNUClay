using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalStorage
{
    public class InternalStorageEngine
    {
        public Dictionary<int, List<RulePart>> mRelationIndex = new Dictionary<int, List<RulePart>>();

        public List<RuleInstance> mRulesAndFactsList = new List<RuleInstance>();
    }
}
