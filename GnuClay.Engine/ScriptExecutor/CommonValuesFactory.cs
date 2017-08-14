using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class CommonValuesFactory : BaseGnuClayEngineComponent
    {
        public CommonValuesFactory(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private ulong mUndefinedTypeKey = 0;
        private IValue mUndefinedValue = null;

        public override void FirstInit()
        {
            var universalTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mUndefinedTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UndefinedTypeMame);
            Context.InheritanceEngine.SetInheritance(mUndefinedTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

            mUndefinedValue = new UndefinedValue(mUndefinedTypeKey);
        }

        public IValue UndefinedValue()
        {
            return mUndefinedValue;
        }

        public IValue CreateDirectFactValue(ulong key)
        {
            return new DirectFactValue(key, Context);
        }

        public IValue CreateArrayOfFacts(SelectResult selectResult)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateArrayOfFacts selectResult = {selectResult}");
#endif

            throw new NotImplementedException();
        }
    }
}
