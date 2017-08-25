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

            mFunctionModel = function.FunctionModel;

            mFilter = function.Filter;
            mFilter.Handler = Handler;
            mFilter.IsUserDefined = true;
            mFilter.FunctionModel = function.FunctionModel;

            mMainContext.FunctionsEngine.AddFilter(mFilter);
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private FunctionModel mFunctionModel = null;
        private CommandFilter mFilter = null;

        private void Handler(EntityAction action)
        {
            mMainContext.FunctionsEngine.CallCodeFrameForEntityAction(mFunctionModel, mFilter, action);
        }
    }

    public class UserDefinedFunctionsStorage : BaseGnuClayEngineComponent
    {
        public UserDefinedFunctionsStorage(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private object mLockObj = new object();

        public void AddFunction(UserDefinedFunctionModel function)
        {
            lock (mLockObj)
            {
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
