using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Bootstrap
{
    public class BootstrapEngine: BaseGnuClayEngineComponent
    {
        public BootstrapEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run()
        {
            InitSelfInstance();
        }

        private void InitSelfInstance()
        {
            var selfInstanceValue = Context.CommonValuesFactory.SelfInstanceValue();
            var selfInstanceVarKey = Context.CommonKeysEngine.SelfSystemVarKey;

            Context.ScriptExecutor.ContextOfSystemVariables.SetVariable(selfInstanceVarKey, selfInstanceValue);
        }
    }
}
