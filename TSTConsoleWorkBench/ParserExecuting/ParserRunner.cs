using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;

namespace TSTConsoleWorkBench.ParserExecuting
{
    public class ParserRunner : BaseRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            //Case1();
            Case2();

            //try
            //{
            //    var queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";
            //    NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");
            //    var result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
            //    NLog.LogManager.GetCurrentClassLogger().Info($"result = {result}");
            //    var tmpInsertQuery = result.InsertQuery;
            //    NLog.LogManager.GetCurrentClassLogger().Info($"`{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, GnuClayEngine.DataDictionary)}`");
            //    GnuClayEngine.LogicalStorage.InsertQuery(tmpInsertQuery);

            //    queryString = "SELECT{son(Piter,$X1)}";
            //    NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");
            //    result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
            //    NLog.LogManager.GetCurrentClassLogger().Info($"result = {result}");

            //    var tmpSelectQuery = result.SelectQuery;
            //    NLog.LogManager.GetCurrentClassLogger().Info(SelectQueryDebugHelper.ConvertToString(tmpSelectQuery, GnuClayEngine.DataDictionary));

            //    var tmpResult = GnuClayEngine.LogicalStorage.SelectQuery(tmpSelectQuery);

            //NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            //    NLog.LogManager.GetCurrentClassLogger().Info($"tmpResult = {tmpResult.ToJson()}");

            //    queryString = "CALL { 1.0 + 2;}";
            //    NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");
            //    result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
            //    NLog.LogManager.GetCurrentClassLogger().Info($"result = {result}");

            //    var tmpCodeFrame = GnuClayEngine.ExecutorEngine.Compiler.Compile(result.ASTCodeBlock);
            //    NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            //    var context = new GnuClayThreadExecutionContext();
            //    context.MainContext = GnuClayEngine.Context;
            //    var tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

            //    tmpInternalThreadExecutor.Run();

            //    queryString = "CALL { 1.0 + 5 + 2;}";
            //    NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");
            //    result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
            //    NLog.LogManager.GetCurrentClassLogger().Info($"result = {result}");

            //    tmpCodeFrame = GnuClayEngine.ExecutorEngine.Compiler.Compile(result.ASTCodeBlock);
            //    NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            //    tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

            //    tmpInternalThreadExecutor.Run();

            //    queryString = "CALL { 1.0 + 5 + 2; 2 + 3;}";
            //    NLog.LogManager.GetCurrentClassLogger().Info($"queryString = `{queryString}`");
            //    result = GnuClayEngine.Context.ParserEngine.Parse(queryString);

            //    tmpCodeFrame = GnuClayEngine.ExecutorEngine.Compiler.Compile(result.ASTCodeBlock);
            //    NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            //    tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

            //    tmpInternalThreadExecutor.Run();
            //}
            //catch (Exception e)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info(e);
            //}
        }

        private void Case1()
        {
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("$var1 = $var2 = 1.0*-5 + 2 + 3 + (4 - 2);");
            tmpSb.AppendLine("}");

            var queryString = tmpSb.ToString();
            NLog.LogManager.GetCurrentClassLogger().Info($"Case1 queryString = `{queryString}`");
            var result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"Case1 result = {result?.ToString(GnuClayEngine.DataDictionary)}");
        }

        private void Case2()
        {
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("$var1 = console.insert.log.bar($var2, 1.0*-5 + 2 + 3).tar().gz.rpzgh<door>($var2);");
            tmpSb.AppendLine("}");

            var queryString = tmpSb.ToString();
            NLog.LogManager.GetCurrentClassLogger().Info($"Case1 queryString = `{queryString}`");
            var result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"Case1 result = {result?.ToString(GnuClayEngine.DataDictionary)}");
        }
    }
}
