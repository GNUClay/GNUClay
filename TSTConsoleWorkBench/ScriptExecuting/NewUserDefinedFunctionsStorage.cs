using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewUserDefinedFunctionsHandler
    {
        public NewUserDefinedFunctionsHandler(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext, NewUserDefinedFunctionModel function)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;

            NLog.LogManager.GetCurrentClassLogger().Info($"NewUserDefinedFunctionsHandler function = {function}");

            mFunctionModel = function.FunctionModel;

            mFilter = function.Filter;
            mFilter.Handler = Handler;

            mAdditionalContext.NewFunctionEngine.AddFilter(mFilter);
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private FunctionModel mFunctionModel = null;
        private NewCommandFilter mFilter = null;

        private void Handler(NewEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin Handler action = {action}");

            mAdditionalContext.NewFunctionEngine.CallCodeFrameForEntityAction(mFunctionModel, mFilter, action);

            NLog.LogManager.GetCurrentClassLogger().Info($"End Handler action = {action}");        
        }
    }

    public class NewUserDefinedFunctionsStorage
    {
        public NewUserDefinedFunctionsStorage(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        private object mLockObj = new object();

        public void AddFunction(NewUserDefinedFunctionModel function)
        {
            lock(mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"AddFunction function = {function}");

                var hashCode = function.Filter.GetLongHashCode();

                if (mDict.ContainsKey(hashCode))
                {
                    throw new NotImplementedException();
                }

                var targetHandler = new NewUserDefinedFunctionsHandler(mMainContext, mAdditionalContext, function);

                mDict[hashCode] = targetHandler;
            }
        }

        private Dictionary<ulong, NewUserDefinedFunctionsHandler> mDict = new Dictionary<ulong, NewUserDefinedFunctionsHandler>();
    }
}
