using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
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

        public NewResultOfCalling CallByNamedParameters(INewValue function, INewValue holder, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var result = new NewResultOfCalling();

            NLog.LogManager.GetCurrentClassLogger().Info("End CallByNamedParameters");

            return result;
        }

        public NewResultOfCalling CallByPositionedParameters(INewValue function, INewValue holder, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var result = new NewResultOfCalling();

            NLog.LogManager.GetCurrentClassLogger().Info("End CallByPositionedParameters");

            return result;
        }

        public NewResultOfCalling CallAsyncByNamedParameters(INewValue function, INewValue holder, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var result = new NewResultOfCalling();

            NLog.LogManager.GetCurrentClassLogger().Info("End ");

            return result;
        }

        public NewResultOfCalling CallAsyncByPositionedParameters(INewValue function, INewValue holder, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var result = new NewResultOfCalling();

            NLog.LogManager.GetCurrentClassLogger().Info("End CallAsyncByPositionedParameters");

            return result;
        }
    }
}
