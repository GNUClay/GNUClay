using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;

namespace TSTConsoleWorkBench.CommonTST
{
    public class CommonRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var tmpGnuClayEngine = new GnuClayEngine();

            var queryString = "SELECT{son(Piter,$X1)}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            var tmpSelectResult = tmpGnuClayEngine.Query(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");

            queryString = "SELECT{son(Piter,Tom)}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            tmpSelectResult = tmpGnuClayEngine.Query(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");

            queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");
            var tmpInsertResult = tmpGnuClayEngine.Query(queryString);

            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertResult = {tmpInsertResult.ToJson()}");

            queryString = "SELECT{son(Piter,$X1)}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            tmpSelectResult = tmpGnuClayEngine.Query(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");

            queryString = "SELECT{son(Piter,Tom)}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            tmpSelectResult = tmpGnuClayEngine.Query(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");

            tmpGnuClayEngine.Clear();

            queryString = "SELECT{son(Piter,$X1)}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            tmpSelectResult = tmpGnuClayEngine.Query(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");

            queryString = "SELECT{son(Piter,Tom)}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            tmpSelectResult = tmpGnuClayEngine.Query(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");
        }
    }
}
