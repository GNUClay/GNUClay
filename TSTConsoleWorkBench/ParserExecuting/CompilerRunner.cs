using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ParserExecuting
{
    public class CompilerRunner : BaseRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Run");
            Case1();
            //Case2();
            //Case3();
            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private void Case1()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case1");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("console.tr.log<!door!>(1);");
            //tmpSb.AppendLine("console.log(1);");
            //tmpSb.AppendLine("console.log<!door!>($a:1);");
            //tmpSb.AppendLine("console.log($a:1);");
            //tmpSb.AppendLine("console.~log<!door!>(1);");
            //tmpSb.AppendLine("console.~log(1);");
            //tmpSb.AppendLine("console.~log<!door!>($a:1);");
            //tmpSb.AppendLine("console.~log($a:1);");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case1");
        }

        private void Case2()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case2");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("$log<!door!>(1);");
            tmpSb.AppendLine("$log(1);");
            tmpSb.AppendLine("$log<!door!>($a:1);");
            tmpSb.AppendLine("$log($a:1);");
            tmpSb.AppendLine("~$log<!door!>(1);");
            tmpSb.AppendLine("~$log(1);");
            tmpSb.AppendLine("~$log<!door!>($a:1);");
            tmpSb.AppendLine("~$log($a:1);");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case2");
        }

        private void Case3()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case2");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("console.log;");
            tmpSb.AppendLine("console.log.as;");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case2");
        }

        private void Compile(string text)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Compile text = {text}");

            var result = GnuClayEngine.Context.ParserEngine.Parse(text);
            NLog.LogManager.GetCurrentClassLogger().Info($"Compile result = {result?.ToString(GnuClayEngine.DataDictionary)}");

            var tmpCodeFrame = GnuClayEngine.ExecutorEngine.Compiler.Compile(result.ASTCodeBlock);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpCodeFrame = {tmpCodeFrame}");
        }
    }
}
