using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class TSTValueProvider : BaseTypeProvider
    {
        public TSTValueProvider(GnuClayEngineComponentContext context)
            : base(context, "tst")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("TSTValueProvider");
        }

        protected override void OnRegType()
        {
            RegType<TstValue>();
        }

        public override IValue Create(object value)
        {
            return new TstValue(ClassInfo, (int)value);
        }
    }
}
