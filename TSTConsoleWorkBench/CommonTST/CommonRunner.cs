using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.DebugHelpers;

namespace TSTConsoleWorkBench.CommonTST
{
    public class CommonRunner
    {
        public void Run()
        {
            try
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Run");

                var tmpGnuClayEngine = new GnuClayEngine();

                /*var queryString = "SELECT{son(Piter,$X1)}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

                var tmpSelectResult = tmpGnuClayEngine.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");

                queryString = "SELECT{son(Piter,Tom)}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

                tmpSelectResult = tmpGnuClayEngine.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");*/

                var queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");
                var tmpInsertResult = tmpGnuClayEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertResult = {tmpInsertResult.ToJson()}");

                queryString = "SELECT{son(Piter,$X1)}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

                var tmpSelectResult = tmpGnuClayEngine.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {SelectResultDebugHelper.ConvertToString(tmpSelectResult, tmpGnuClayEngine.DataDictionary)}");

                queryString = "SELECT{son(Piter,Tom)}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

                tmpSelectResult = tmpGnuClayEngine.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {SelectResultDebugHelper.ConvertToString(tmpSelectResult, tmpGnuClayEngine.DataDictionary)}");

                queryString = "SELECT{son($X, $Y)}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

                tmpSelectResult = tmpGnuClayEngine.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {SelectResultDebugHelper.ConvertToString(tmpSelectResult, tmpGnuClayEngine.DataDictionary)}");

                /*tmpGnuClayEngine.Clear();

                queryString = "SELECT{son(Piter,$X1)}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

                tmpSelectResult = tmpGnuClayEngine.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");

                queryString = "SELECT{son(Piter,Tom)}";
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

                tmpSelectResult = tmpGnuClayEngine.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");*/
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
