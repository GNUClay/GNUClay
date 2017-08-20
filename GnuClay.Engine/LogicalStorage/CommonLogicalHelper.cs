using GnuClay.CommonClientTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    public class CommonLogicalHelper : BaseLogicalStorageComponent
    {
        public CommonLogicalHelper(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
            : base(context, logicalContext)
        {
        }

        private InheritanceEngine mInheritanceEngine = null;
        private StorageDataDictionary mDataDictionary = null;

        private ulong mLogicalRuleTypeKey = 0;
        private ulong mFactTypeKey = 0;

        private ulong UniversalTypeKey = 1;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
            mInheritanceEngine = Context.InheritanceEngine;
        }

        public override void SecondInit()
        {
            mLogicalRuleTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.LogicalRuleName);
            mInheritanceEngine.SetInheritance(mLogicalRuleTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
            mFactTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.FactName);
            mInheritanceEngine.SetInheritance(mFactTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
        }

        public ulong GetFactKey()
        {
            var name = Guid.NewGuid().ToString("D");
            var key = mDataDictionary.GetKey(name);
            mInheritanceEngine.SetInheritance(key, mFactTypeKey, 1, InheritanceAspect.WithOutClause);
            return key;
        }

        public ulong GetRuleKey()
        {
            var name = Guid.NewGuid().ToString("D");
            var key = mDataDictionary.GetKey(name);
            mInheritanceEngine.SetInheritance(key, mLogicalRuleTypeKey, 1, InheritanceAspect.WithOutClause);
            return key;
        }

        public ExpressionNode CreateExpressionNode(IValue value)
        {
            var result = new ExpressionNode();
            result.Key = value.TypeKey;

            var kind = value.Kind;

            switch(kind)
            {
                case KindOfValue.Logical:
                    result.Kind = ExpressionNodeKind.Entity;
                    break;

                case KindOfValue.Value:
                    if (value.IsFact)
                    {
                        result.Kind = ExpressionNodeKind.Entity;
                        break;
                    }

                    result.Kind = ExpressionNodeKind.Value;
                    result.Value = value.Value;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }

            return result;
        }

        public ExpressionNode CreateVarExpressionNode(ulong variableKey)
        {
            var variableNode = new ExpressionNode();
            variableNode.Kind = ExpressionNodeKind.Var;
            variableNode.Key = variableKey;

            return variableNode;
        }
    }
}
