using MyNPCLib.CGStorage;
using MyNPCLib.DebugHelperForPersistLogicalData;
using MyNPCLib.Parser.LogicalExpression;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.LogicalSoundModeling
{
    public static class LogicalSoundDiscoverer
    {
        public static LogicalSoundInfo GetInfo(ICGStorage source)
        {
            var result = new LogicalSoundInfo();
            result.Storage = source;

            var entitydictionary = source.EntityDictionary;

            var localStorage = new LocalCGStorage(entitydictionary);

            localStorage.Append(source);

            var actionName = string.Empty;

            {
                var queryStr = "{: ?Z(?X,?Y)[: {: command :} :] :}";

                var queryStorage = RuleInstanceFactory.ConvertStringToQueryCGStorage(queryStr, entitydictionary);
                var query = queryStorage.MainRuleInstance;

#if DEBUG
                //{
                    //var debugStr = DebugHelperForRuleInstance.ToString(query);

                    //LogInstance.Log($"debugStr = {debugStr}");
                //}
#endif
                var querySearchResultCGStorage = localStorage.Search(queryStorage);

                var keyOfActionQuestionVar = entitydictionary.GetKey("?Z");

#if DEBUG
                //LogInstance.Log($"keyOfActionQuestionVar = {keyOfActionQuestionVar}");
#endif

                var actionExpression = querySearchResultCGStorage.GetResultOfVar(keyOfActionQuestionVar);

#if DEBUG
                //LogInstance.Log($"actionExpression = {actionExpression}");
#endif
                if (actionExpression != null)
                {
                    actionName = actionExpression?.FoundExpression?.AsRelation.Name;
                }
            }

#if DEBUG
            //LogInstance.Log($"!!!!!!!! :) actionName = {actionName}");
#endif

            if(!string.IsNullOrWhiteSpace(actionName))
            {
                result.ActionName = actionName;
                result.Kind = KindOfSoundEvent.Command;
                return result;
            }

            {
                var queryStr = "{: ?Z(?X,?Y)[: {: action :} :] :}";

                var queryStorage = RuleInstanceFactory.ConvertStringToQueryCGStorage(queryStr, entitydictionary);
                var query = queryStorage.MainRuleInstance;

#if DEBUG
                //{
                    //var debugStr = DebugHelperForRuleInstance.ToString(query);

                    //LogInstance.Log($"debugStr = {debugStr}");
                //}
#endif
                var querySearchResultCGStorage = localStorage.Search(queryStorage);

                var keyOfActionQuestionVar = entitydictionary.GetKey("?Z");

#if DEBUG
                //LogInstance.Log($"keyOfActionQuestionVar = {keyOfActionQuestionVar}");
#endif

                var actionExpression = querySearchResultCGStorage.GetResultOfVar(keyOfActionQuestionVar);

#if DEBUG
                //LogInstance.Log($"actionExpression = {actionExpression}");
#endif
                if (actionExpression != null)
                {
                    actionName = actionExpression?.FoundExpression?.AsRelation.Name;
                }
            }

#if DEBUG
            //LogInstance.Log($"!!!!!!!! :) actionName = {actionName}");
#endif

            if(!string.IsNullOrWhiteSpace(actionName))
            {
                result.ActionName = actionName;
                result.Kind = KindOfSoundEvent.Fact;
                return result;
            }

            {
                var queryStr = "{: ?Z(?X,?Y)[: {: state :} :] :}";

                var queryStorage = RuleInstanceFactory.ConvertStringToQueryCGStorage(queryStr, entitydictionary);
                var query = queryStorage.MainRuleInstance;

#if DEBUG
                //{
                    //var debugStr = DebugHelperForRuleInstance.ToString(query);

                    //LogInstance.Log($"debugStr = {debugStr}");
                //}
#endif
                var querySearchResultCGStorage = localStorage.Search(queryStorage);

                var keyOfActionQuestionVar = entitydictionary.GetKey("?Z");

#if DEBUG
                //LogInstance.Log($"keyOfActionQuestionVar = {keyOfActionQuestionVar}");
#endif

                var actionExpression = querySearchResultCGStorage.GetResultOfVar(keyOfActionQuestionVar);

#if DEBUG
                //LogInstance.Log($"actionExpression = {actionExpression}");
#endif
                if (actionExpression != null)
                {
                    actionName = actionExpression?.FoundExpression?.AsRelation.Name;
                }
            }

#if DEBUG
            //LogInstance.Log($"!!!!!!!! :) actionName = {actionName}");
#endif

            if (!string.IsNullOrWhiteSpace(actionName))
            {
                result.ActionName = actionName;
                result.Kind = KindOfSoundEvent.Fact;
                return result;
            }

            result.Kind = KindOfSoundEvent.EntityCondition;
            return result;
        }
    }
}
