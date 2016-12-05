using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.LocalHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.LocalHostExecuting
{
    public class LocalHostRunner
    {
        public LocalHostRunner()
        {
            mServerConnection = new GnuClayLocalServer();
            mEntityConnection = mServerConnection.ConnectToEntity(mEntityName);
        }

        private string mEntityName = "#0813940A-EAC6-47E7-BF57-9B8C05E2168A";
        private IGnuClayServerConnection mServerConnection = null;
        private IGnuClayEntityConnection mEntityConnection = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            var result = mEntityConnection.Query(queryString);
            DisplayResult(result);

            queryString = "SELECT{son(Piter,$X1)}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            result = mEntityConnection.Query(queryString);
            DisplayResult(result);

            queryString = "CALL { 1.0 + 2;}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            result = mEntityConnection.Query(queryString);
            DisplayResult(result);

            queryString = "CALL { 1.0 + 5 + 2;}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            result = mEntityConnection.Query(queryString);
            DisplayResult(result);

            queryString = "CALL { 1.0 + 5 + 2; 2 + 3;}";
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");

            result = mEntityConnection.Query(queryString);
            DisplayResult(result);
        }

        private void DisplayResult(SelectResult result)
        {
            if(result == null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("result == null");
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(result, null));
        }
    }
}
