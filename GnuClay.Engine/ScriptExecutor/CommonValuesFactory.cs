using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.CommonStorages;
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

        private InheritanceEngine mInheritanceEngine = null;
        private StorageDataDictionary mDataDictionary = null;

        private ulong mUndefinedTypeKey = 0;
        private IValue mUndefinedValue = null;

        private static string ParamVarName = "$x1";
        private ulong ParamVarKey = 0;

        private ulong mFactTypeKey = 0;
        private ulong mArrayTypeKey = 0;
        private ulong UniversalTypeKey = 1;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
            mInheritanceEngine = Context.InheritanceEngine;
        }

        public override void SecondInit()
        {
            var universalTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mUndefinedTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.UndefinedTypeMame);
            mInheritanceEngine.SetInheritance(mUndefinedTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

            mUndefinedValue = new UndefinedValue(mUndefinedTypeKey);

            ParamVarKey = mDataDictionary.GetKey(ParamVarName);

            mFactTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.FactName);
            mInheritanceEngine.SetInheritance(mFactTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            mArrayTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.ArrayName);
            mInheritanceEngine.SetInheritance(mArrayTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
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
            var name = Guid.NewGuid().ToString("D");
            var key = mDataDictionary.GetKey(name);
            mInheritanceEngine.SetInheritance(key, mFactTypeKey, 1, InheritanceAspect.WithOutClause);
            mInheritanceEngine.SetInheritance(key, mArrayTypeKey, 1, InheritanceAspect.WithOutClause);

            return new ArrayOfFactsValue(key, selectResult, Context);
        }
    }
}
