using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.OperatorsSupport
{
    public class OperatorAssignProvider: BaseGnuClayEngineComponent
    {
        public OperatorAssignProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private ulong AssignOperatorKey = 0;

        public override void SecondInit()
        {
            AssignOperatorKey = Context.CommonKeysEngine.AssignOperatorKey;


        }
    }
}
