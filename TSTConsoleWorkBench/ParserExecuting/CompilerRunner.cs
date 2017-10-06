using GnuClay.CommonClientTypes.CommonData;
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
            //Case1();
            //Case2();
            //Case3();
            //Case4();
            //Case5();
            //Case6();
            //Case7();
            //Case8();
            //Case9();
            //Case10();
            Case11();
            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private void Case1()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case1");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("console.log<!door!>(1);");
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
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case3");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("console.log;");
            tmpSb.AppendLine("console.log.tr;");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case3");
        }

        private void Case4()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case4");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("$var1 = console.log.tr + 4 * 2;");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case4");
        }

        private void Case5()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case5");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("$var1 = console.log.tr<!door!>($a:1) + 4 * 2;");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case5");
        }

        private void Case6()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case6");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("    if($var1 == 1)");
            tmpSb.AppendLine("    {");
            tmpSb.AppendLine("        $var2 = $var3;");
            tmpSb.AppendLine("    };");
            tmpSb.AppendLine("    if($var1 == 1)");
            tmpSb.AppendLine("    {");
            tmpSb.AppendLine("        $var2 = $var3;");
            tmpSb.AppendLine("    }else{");
            tmpSb.AppendLine("        $var2 = $var4;");
            tmpSb.AppendLine("    };");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case6");
        }

        private void Case7()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case7");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("    while($var1 == 1)");
            tmpSb.AppendLine("    {");
            tmpSb.AppendLine("        $var2 = $var3;");
            tmpSb.AppendLine("    };");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case7");
        }

        private void Case8()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case8");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("    $var1 = 1;");
            tmpSb.AppendLine("    while($var1 == 1)");
            tmpSb.AppendLine("    {");
            tmpSb.AppendLine("        $var1 = 0.5;");
            tmpSb.AppendLine("    };");
            tmpSb.AppendLine("}");

            GnuClayEngine.Query(tmpSb.ToString());

            NLog.LogManager.GetCurrentClassLogger().Info("End Case8");
        }

        private void Case9()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case9");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("DEFINE {");
            tmpSb.AppendLine("    fun run<!door!>($a: number, $b: number, $c: number)");
            tmpSb.AppendLine("    subj: dog;");
            tmpSb.AppendLine("    {");
            tmpSb.AppendLine("        return 1;");
            tmpSb.AppendLine("    }");
            tmpSb.AppendLine("}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Case9 tmpSb.ToString() = {tmpSb.ToString()}");

            GnuClayEngine.Query(tmpSb.ToString());

            tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("    dog.run<!door!>(1,2,3);");
            tmpSb.AppendLine("}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Case9 tmpSb.ToString() = {tmpSb.ToString()}");

            GnuClayEngine.Query(tmpSb.ToString());

            NLog.LogManager.GetCurrentClassLogger().Info("End Case9");
        }

        private void Case10()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case10");

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("$$console.log<!door!>(1);");
            //tmpSb.AppendLine("$$console.log(1);");
            //tmpSb.AppendLine("$$console.log<!door!>($a:1);");
            //tmpSb.AppendLine("$$console.log($a:1);");
            //tmpSb.AppendLine("$$console.~log<!door!>(1);");
            //tmpSb.AppendLine("$$console.~log(1);");
            //tmpSb.AppendLine("$$console.~log<!door!>($a:1);");
            //tmpSb.AppendLine("$$console.~log($a:1);");
            tmpSb.AppendLine("}");

            Compile(tmpSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info("End Case10");
        }

        private void Case11()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case11");

            GnuClayEngine.AddLogHandler((IExternalValue value) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"Case11 value = {value}");
            });

            var dogKey = GnuClayEngine.DataDictionary.GetKey("dog");
            var remoteKey = GnuClayEngine.DataDictionary.GetKey("remote");
            var doorKey = GnuClayEngine.DataDictionary.GetKey("door");
            var keyKey = GnuClayEngine.DataDictionary.GetKey("$key");

            var externalFilter = new ExternalCommandFilter();
            externalFilter.HolderKey = dogKey;
            externalFilter.FunctionKey = remoteKey;
            externalFilter.TargetKey = doorKey;

            externalFilter.Params.Add(keyKey, new ExternalCommandFilterParam()
            {
            });

            externalFilter.Handler = FakeRemoteHandler_1;

            GnuClayEngine.AddRemoteFunction(externalFilter);

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("DEFINE {");
            tmpSb.AppendLine("    fun run<!door!>($a: number, $b: number, $c: number)");
            tmpSb.AppendLine("    subj: dog;");
            tmpSb.AppendLine("    {");
            tmpSb.AppendLine("        return $$self;");
            tmpSb.AppendLine("    }");
            tmpSb.AppendLine("}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Case9 tmpSb.ToString() = {tmpSb.ToString()}");

            //GnuClayEngine.Query(tmpSb.ToString());

            //tmpSb = new StringBuilder();
            tmpSb.AppendLine("CALL {");
            tmpSb.AppendLine("    dog.run<!door!>(1,2,3);");
            tmpSb.AppendLine("    dog.remote<!door!>(1);");
            tmpSb.AppendLine("    console.log(1 + 2);");
            tmpSb.AppendLine("    console.log(1 - 1);");
            tmpSb.AppendLine("    console.log(3 * 2);");
            tmpSb.AppendLine("    console.log(8 / 2);");
            tmpSb.AppendLine("    console.log($var1 == 2);");
            tmpSb.AppendLine("    $var2 = 1;");
            tmpSb.AppendLine("    console.log($var2);");
            tmpSb.AppendLine("    $var2 += 1;");
            tmpSb.AppendLine("    console.log($var2);");
            tmpSb.AppendLine("}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Case9 tmpSb.ToString() = {tmpSb.ToString()}");

            GnuClayEngine.Query(tmpSb.ToString());

            NLog.LogManager.GetCurrentClassLogger().Info("End Case11");
        }

        private void FakeRemoteHandler_1(IExternalEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_1 action = {action?.ToString(GnuClayEngine.DataDictionary, 0)}");

            var command = action.Command;

            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_1 command = {command?.ToString(GnuClayEngine.DataDictionary, 0)}");

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeRemoteHandler_1 action = {action?.ToString(GnuClayEngine.DataDictionary, 0)}");
        }

        private void Compile(string text)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Compile text = {text}");

            var result = GnuClayEngine.Context.ParserEngine.Parse(text).FirstOrDefault();
            NLog.LogManager.GetCurrentClassLogger().Info($"Compile result = {result?.ToString(GnuClayEngine.DataDictionary)}");

            var tmpCodeFrame = GnuClayEngine.Context.ScriptCompiler.Compile(result.ASTCodeBlock);
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpCodeFrame = {tmpCodeFrame?.ToString(GnuClayEngine.DataDictionary, 0)}");
        }
    }
}
