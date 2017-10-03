using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.OperatorsSupport
{
    public class LogicalOperatorsProvider : BaseGnuClayEngineComponent
    {
        public LogicalOperatorsProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private StorageDataDictionary DataDictionary;
        private CommonKeysEngine CommonKeysEngine;
        private FunctionsEngine FunctionsEngine;
        private ConstTypeProvider ConstTypeProvider;

        public override void FirstInit()
        {
            DataDictionary = Context.DataDictionary;
            CommonKeysEngine = Context.CommonKeysEngine;
            FunctionsEngine = Context.FunctionsEngine;
            ConstTypeProvider = Context.ConstTypeProvider;
        }

        private ulong SelfInstanceKey;
        private ulong FirstParamKey;
        private ulong SecondParamKey;
        private ulong BooleanKey;
        private ulong EqualOperatorKey;
        private ulong NotEqualOperatorKey;
        private ulong MoreOperatorKey;
        private ulong LessOperatorKey;
        private ulong AndOperatorKey;
        private ulong OrOperatorKey;
        private ulong MoreOrEqualOperatorKey;
        private ulong LessOrEqualOperatorKey;

        public override void SecondInit()
        {
            SelfInstanceKey = CommonKeysEngine.SelfInstanceKey;
            FirstParamKey = CommonKeysEngine.FirstParamKey;
            SecondParamKey = CommonKeysEngine.SecondParamKey;
            BooleanKey = CommonKeysEngine.BooleanKey;
            EqualOperatorKey = CommonKeysEngine.EqualOperatorKey;
            NotEqualOperatorKey = CommonKeysEngine.NotEqualOperatorKey;
            MoreOperatorKey = CommonKeysEngine.MoreOperatorKey;
            LessOperatorKey = CommonKeysEngine.LessOperatorKey;
            AndOperatorKey = CommonKeysEngine.AndOperatorKey;
            OrOperatorKey = CommonKeysEngine.OrOperatorKey;
            MoreOrEqualOperatorKey = CommonKeysEngine.MoreOrEqualOperatorKey;
            LessOrEqualOperatorKey = CommonKeysEngine.LessOrEqualOperatorKey;

            RegHandlerOfEqual();
            RegHandlerOfNotEqual();
            RegHandlerOfMore();
            RegHandlerOfLess();
            RegHandlerOfAnd();
            RegHandlerOfOr();
            RegHandlerOfMoreOrEqual();
            RegHandlerOfLessOrEqual();
        }

        private void RegHandlerOfEqual()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfEqual;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = EqualOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfEqual(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfEqual action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        private void RegHandlerOfNotEqual()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfNotEqual;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = NotEqualOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfNotEqual(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfNotEqual action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        private void RegHandlerOfMore()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfMore;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = MoreOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfMore(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfMore action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        private void RegHandlerOfLess()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfLess;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = LessOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfLess(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfLess action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        private void RegHandlerOfAnd()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfAnd;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = AndOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfAnd(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfAnd action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        private void RegHandlerOfOr()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfOr;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = OrOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfOr(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfOr action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        private void RegHandlerOfMoreOrEqual()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfMoreOrEqual;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = MoreOrEqualOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfMoreOrEqual(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfMoreOrEqual action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        private void RegHandlerOfLessOrEqual()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfLessOrEqual;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = LessOrEqualOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = BooleanKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfLessOrEqual(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfLessOrEqual action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }
    }
}
