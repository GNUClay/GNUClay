using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewFunctionsEngine
    {
        public NewFunctionsEngine(GnuClayEngineComponentContext context)
        {
            mContext = context;
        }

        private GnuClayEngineComponentContext mContext = null;

        public void CallCodeFrame(FunctionModel source)
        {
            var context = new NewGnuClayThreadExecutionContext();
            context.NewFunctionEngine = this;
            context.ContextOfVariables = new NewContextOfVariables();

            var tmpNewInternalThreadExecutor = new NewInternalFunctionExecutionModel(source, mContext, context);
            tmpNewInternalThreadExecutor.Run();
        }

        public NewResultOfCalling CallByNamedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var result = new NewResultOfCalling();
            result.Success = true;//tmp
            result.Result = new NewEntityValue(15);//tmp

            NLog.LogManager.GetCurrentClassLogger().Info("End CallByNamedParameters");

            return result;
        }

        public NewResultOfCalling CallByPositionedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var result = new NewResultOfCalling();
            result.Success = true;//tmp
            result.Result = new NewEntityValue(15);//tmp

            NLog.LogManager.GetCurrentClassLogger().Info("End CallByPositionedParameters");

            return result;
        }

        public NewResultOfCalling CallAsyncByNamedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var result = new NewResultOfCalling();


            NLog.LogManager.GetCurrentClassLogger().Info("End CallAsyncByNamedParameters");

            return result;
        }

        public NewResultOfCalling CallAsyncByPositionedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var result = new NewResultOfCalling();

            NLog.LogManager.GetCurrentClassLogger().Info("End CallAsyncByPositionedParameters");

            return result;
        }
    }
}
