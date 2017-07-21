using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class UserDefinedFunctionsHandler
    {
        public UserDefinedFunctionsHandler(GnuClayEngineComponentContext mainContext, UserDefinedFunctionModel function)
        {
            mMainContext = mainContext;

            NLog.LogManager.GetCurrentClassLogger().Info($"NewUserDefinedFunctionsHandler function = {function}");

            mFunctionModel = function.FunctionModel;

            mFilter = function.Filter;
            mFilter.Handler = Handler;

            mMainContext.FunctionsEngine.AddFilter(mFilter);
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private FunctionModel mFunctionModel = null;
        private CommandFilter mFilter = null;

        private void Handler(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin Handler action = {action}");

            mMainContext.FunctionsEngine.CallCodeFrameForEntityAction(mFunctionModel, mFilter, action);

            NLog.LogManager.GetCurrentClassLogger().Info($"End Handler action = {action}");
        }
    }

    public class UserDefinedFunctionsStorage : BaseGnuClayEngineComponent
    {
        public UserDefinedFunctionsStorage(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private object mLockObj = new object();

        public void AddFunction(UserDefinedFunctionModel function)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"AddFunction function = {function}");

                var hashCode = function.Filter.GetLongHashCode();

                if (mDict.ContainsKey(hashCode))
                {
                    throw new NotImplementedException();
                }

                var targetHandler = new UserDefinedFunctionsHandler(Context, function);

                mDict[hashCode] = targetHandler;
            }
        }

        private Dictionary<ulong, UserDefinedFunctionsHandler> mDict = new Dictionary<ulong, UserDefinedFunctionsHandler>();
    }
}
