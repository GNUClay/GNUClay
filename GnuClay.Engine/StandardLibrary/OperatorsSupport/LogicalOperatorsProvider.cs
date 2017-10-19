using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
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
        private CommonValuesFactory CommonValuesFactory;
        private CommonKeysEngine CommonKeysEngine;
        private FunctionsEngine FunctionsEngine;
        private ConstTypeProvider ConstTypeProvider;

        public override void FirstInit()
        {
            DataDictionary = Context.DataDictionary;
            CommonValuesFactory = Context.CommonValuesFactory;
            CommonKeysEngine = Context.CommonKeysEngine;
            FunctionsEngine = Context.FunctionsEngine;
            ConstTypeProvider = Context.ConstTypeProvider;
        }

        private ulong SelfInstanceKey;
        private ulong FirstParamKey;
        private ulong SecondParamKey;
        private ulong BooleanKey;
        private ulong NumberKey;
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
            NumberKey = CommonKeysEngine.NumberKey;
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
                IsAnyType = true
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = true
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfEqual(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

//#if DEBUG
//            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfEqual tmpParam_1 = {tmpParam_1.ToString(DataDictionary, 0)}");
//            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfEqual tmpParam_2 = {tmpParam_2.ToString(DataDictionary, 0)}");
//#endif

            if(tmpParam_1.TypeKey != tmpParam_2.TypeKey)
            {
                action.Result = CommonValuesFactory.FalseValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if(tmpParam_1.Kind == KindOfValue.Value)
            {
                if(tmpParam_1.Value == null && tmpParam_2.Value == null)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if(!tmpParam_1.Value.Equals(tmpParam_2.Value))
                {
//#if DEBUG
//                    NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfEqual tmpParam_1.Value = {tmpParam_1.Value}");
//                    NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfEqual tmpParam_2.Value = {tmpParam_2.Value}");
//#endif

                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            action.Result = CommonValuesFactory.TrueValue();
            action.State = EntityActionState.Completed;
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
                IsAnyType = true
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = true
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfNotEqual(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfNotEqual tmpParam_1 = {tmpParam_1.ToString(DataDictionary, 0)}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfNotEqual tmpParam_2 = {tmpParam_2.ToString(DataDictionary, 0)}");
#endif

            if (tmpParam_1.TypeKey != tmpParam_2.TypeKey)
            {
                action.Result = CommonValuesFactory.TrueValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.Kind == KindOfValue.Value)
            {
                if (tmpParam_1.Value == null && tmpParam_2.Value == null)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (!tmpParam_1.Value.Equals(tmpParam_2.Value))
                {
//#if DEBUG
//                    NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfEqual tmpParam_1.Value = {tmpParam_1.Value}");
//                    NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfEqual tmpParam_2.Value = {tmpParam_2.Value}");
//#endif

                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            action.Result = CommonValuesFactory.FalseValue();
            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfMore()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfMore_Boolean_Boolean;
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

            filter = new CommandFilter();
            filter.Handler = HandlerOfMore_Number_Number;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = MoreOperatorKey;
            filter.TargetKey = 0;

            filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfMore_Boolean_Boolean(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.FalseValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if(tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if(tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (BooleanValue)tmpParam_1;
            var tmpParamNumberValue_2 = (BooleanValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue > tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }

        private void HandlerOfMore_Number_Number(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.FalseValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if (tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue > tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfLess()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfLess_Boolean_Boolean;
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

            filter = new CommandFilter();
            filter.Handler = HandlerOfLess_Number_Number;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = LessOperatorKey;
            filter.TargetKey = 0;

            filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfLess_Boolean_Boolean(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.FalseValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if (tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (BooleanValue)tmpParam_1;
            var tmpParamNumberValue_2 = (BooleanValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue < tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }

        private void HandlerOfLess_Number_Number(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.FalseValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if (tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue < tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfAnd()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfAnd_Boolean_Boolean;
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

        private void HandlerOfAnd_Boolean_Boolean(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.NullValue();
                action.State = EntityActionState.Completed;
                return;
            }

            var tmpParamNumberValue_1 = (BooleanValue)tmpParam_1;
            var tmpParamNumberValue_2 = (BooleanValue)tmpParam_2;

            var originalResult = Math.Min(tmpParamNumberValue_1.OriginalValue, tmpParamNumberValue_2.OriginalValue);
            action.Result = ConstTypeProvider.CreateConstValue(BooleanKey, originalResult);
            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfOr()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfOr_Boolean_Boolean;
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

        private void HandlerOfOr_Boolean_Boolean(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.NullValue();
                action.State = EntityActionState.Completed;
                return;
            }

            var tmpParamNumberValue_1 = (BooleanValue)tmpParam_1;
            var tmpParamNumberValue_2 = (BooleanValue)tmpParam_2;

            var originalResult = Math.Max(tmpParamNumberValue_1.OriginalValue, tmpParamNumberValue_2.OriginalValue);
            action.Result = ConstTypeProvider.CreateConstValue(BooleanKey, originalResult);
            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfMoreOrEqual()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfMoreOrEqual_Boolean_Boolean;
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

            filter = new CommandFilter();
            filter.Handler = HandlerOfMoreOrEqual_Number_Number;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = MoreOrEqualOperatorKey;
            filter.TargetKey = 0;

            filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfMoreOrEqual_Boolean_Boolean(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.TrueValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if (tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (BooleanValue)tmpParam_1;
            var tmpParamNumberValue_2 = (BooleanValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue >= tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }

        private void HandlerOfMoreOrEqual_Number_Number(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.TrueValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if (tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue >= tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfLessOrEqual()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfLessOrEqual_Boolean_Boolean;
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

            filter = new CommandFilter();
            filter.Handler = HandlerOfLessOrEqual_Number_Number;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = LessOrEqualOperatorKey;
            filter.TargetKey = 0;

            filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfLessOrEqual_Boolean_Boolean(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.TrueValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if (tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (BooleanValue)tmpParam_1;
            var tmpParamNumberValue_2 = (BooleanValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue <= tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }

        private void HandlerOfLessOrEqual_Number_Number(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull && tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.TrueValue();
                action.State = EntityActionState.Completed;
                return;
            }

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                if (tmpParam_1.IsNull)
                {
                    action.Result = CommonValuesFactory.TrueValue();
                    action.State = EntityActionState.Completed;
                    return;
                }

                if (tmpParam_2.IsNull)
                {
                    action.Result = CommonValuesFactory.FalseValue();
                    action.State = EntityActionState.Completed;
                    return;
                }
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;

            if (tmpParamNumberValue_1.OriginalValue <= tmpParamNumberValue_2.OriginalValue)
            {
                action.Result = CommonValuesFactory.TrueValue();
            }
            else
            {
                action.Result = CommonValuesFactory.FalseValue();
            }

            action.State = EntityActionState.Completed;
        }
    }
}