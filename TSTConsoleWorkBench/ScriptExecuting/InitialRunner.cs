using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class InitialRunner: BaseRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");
            try
            {
                var tmpTSTProvider = new TSTValueProvider(GnuClayEngine.Context);
                tmpTSTProvider.InitFromZero();
                var tmpVal = tmpTSTProvider.Create(15);
                var targetKey = GnuClayEngine.DataDictionary.GetKey("SecondMethod");
                NLog.LogManager.GetCurrentClassLogger().Info($"SecondMethod targetKey = `{targetKey}`");

                var rez = tmpVal.TryCall(targetKey, new List<IValue>());

                NLog.LogManager.GetCurrentClassLogger().Info($"SecondMethod rez.Result = `{rez.Result}`");

                targetKey = GnuClayEngine.DataDictionary.GetKey("SomeMethod");
                NLog.LogManager.GetCurrentClassLogger().Info($"SomeMethod targetKey = `{targetKey}`");

                rez = tmpVal.TryCall(targetKey, new List<IValue>());

                NLog.LogManager.GetCurrentClassLogger().Info($"SomeMethod rez.Result = `{rez.Result}`");

                var numberKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);

                NLog.LogManager.GetCurrentClassLogger().Info($"numberKey = `{numberKey}`");

                var numberValue = GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 12);

                NLog.LogManager.GetCurrentClassLogger().Info($"numberValue = `{numberValue}`");

                var tmpParamNameKey = GnuClayEngine.DataDictionary.GetKey("a");

                var externalMethodInfoKey = GnuClayEngine.DataDictionary.GetKey("Move");
                var externalMethodInfo = new ExternalMethodInfo();
                externalMethodInfo.MethodKey = externalMethodInfoKey;
                externalMethodInfo.HolderKey = numberKey;
                externalMethodInfo.Parameters.Add(new ExternalParameterInfo() {
                    NameKey = tmpParamNameKey,
                    ParameterType = numberKey
                });

                GnuClayEngine.Context.TypeProcessingContext.RegExternalMethod(externalMethodInfo);

                rez = numberValue.TryCall(externalMethodInfoKey, new List<IValue>() { numberValue });

                NLog.LogManager.GetCurrentClassLogger().Info($"externalMethodInfo rez.Result = `{rez.Result}`");
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
