using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using TSTConsoleWorkBench.CommonTST;
using TSTConsoleWorkBench.LocalHostExecuting;
using TSTConsoleWorkBench.LogicalStorage.Insert;
using TSTConsoleWorkBench.ParserExecuting;
using TSTConsoleWorkBench.ScriptExecuting;
using TSTConsoleWorkBench.Serialiazation;

namespace TSTConsoleWorkBench
{
    internal delegate void SignalHandler(ConsoleSignal consoleSignal);

    internal enum ConsoleSignal
    {
        CtrlC = 0,
        CtrlBreak = 1,
        Close = 2,
        LogOff = 5,
        Shutdown = 6
    }

    internal static class ConsoleHelper
    {
        [DllImport("Kernel32", EntryPoint = "SetConsoleCtrlHandler")]
        public static extern bool SetSignalHandler(SignalHandler handler, bool add);
    }

    class Program
    {
        private static SignalHandler signalHandler;

        static void Main(string[] args)
        {
            signalHandler += HandleConsoleSignal;
            ConsoleHelper.SetSignalHandler(signalHandler, true);

            /*while (true)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Main Tick");
                Thread.Sleep(1000);
            }*/
            
            //TSTGnuClayLocalServerSerializationRunner();
            //TSTEntityConnectionSerializationRunner();
            //TSTSerializationRunner();
            //TSTLocalHostRunner();
            //TSTParserRunner();
            //TSTCommonRunner();
            //TSTInitialRunner();
            //TSTRunInsert();
            //TSTStorageDataDictionary();
            //CreateMyFirstExpressionTree();
        }

        private static void HandleConsoleSignal(ConsoleSignal consoleSignal)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"HandleConsoleSignal consoleSignal = {consoleSignal}");

            /*while (true)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("HandleConsoleSignal Tick");
                Thread.Sleep(1000);
            }*/
        }

        private static void TSTGnuClayLocalServerSerializationRunner()
        {
            var tmpGnuClayLocalServerSerializationRunner = new GnuClayLocalServerSerializationRunner();
            tmpGnuClayLocalServerSerializationRunner.Run();
        }

        private static void TSTEntityConnectionSerializationRunner()
        {
            var tmpEntityConnectionSerializationRunner = new EntityConnectionSerializationRunner();
            tmpEntityConnectionSerializationRunner.Run();
        }

        private static void TSTSerializationRunner()
        {
            var tmpSerializationRunner = new SerializationRunner();
            tmpSerializationRunner.Run();
        }

        private static void TSTLocalHostRunner()
        {
            try
            {
                var tmpLocalHostRunner = new LocalHostRunner();
                tmpLocalHostRunner.Run();
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }

        private static void TSTParserRunner()
        {
            var tmpParserRunner = new ParserRunner();
            tmpParserRunner.Run();
        }

        private static void TSTCommonRunner()
        {
            var tmpCommonRunner = new CommonRunner();
            tmpCommonRunner.Run();
        }

        private static void TSTInitialRunner()
        {
            var tmpInitialRunner = new InitialRunner();
            tmpInitialRunner.Run();
        }

        private static void TSTRunInsert()
        {
            var tmpLogicalStorageInsertRunner = new LogicalStorageInsertRunner();

            tmpLogicalStorageInsertRunner.Run();
        }

        private static void TSTStorageDataDictionary()
        {
            var tmpStorageDataDictionary = new StorageDataDictionary(null);

            var tmpStr = "parent";

            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");

            NLog.LogManager.GetCurrentClassLogger().Info($"tmpStorageDataDictionary.UniqueKeysCount() = {tmpStorageDataDictionary.UniqueKeysCount()}");

            tmpStr = "male";

            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");

            NLog.LogManager.GetCurrentClassLogger().Info($"tmpStorageDataDictionary.UniqueKeysCount() = {tmpStorageDataDictionary.UniqueKeysCount()}");
        }

        private static void CreateMyFirstExpressionTree()
        {
            //Represents sentence:`parent($X, $Y) & male($Y)`
            //Global data dictionary:
            //parent - 1;
            //male - 2;
            //Variables data dictionary:
            //$X - 1;
            //$Y - 2;

            var tmpRootNode = new ExpressionNode();

            tmpRootNode.Kind = ExpressionNodeKind.And;

            var tmpLeftNode = new ExpressionNode();

            tmpRootNode.Left = tmpLeftNode;

            tmpLeftNode.Kind = ExpressionNodeKind.Relation;

            tmpLeftNode.RelationParams = new List<ExpressionNode>();

            tmpLeftNode.Key = 1;

            var tmpParam = new ExpressionNode();

            tmpLeftNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;
            tmpParam.Key = 1;

            tmpParam = new ExpressionNode();

            tmpLeftNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;
            tmpParam.Key = 2;

            var tmpRightNode = new ExpressionNode();

            tmpRootNode.Right = tmpRightNode;

            tmpRightNode.Kind = ExpressionNodeKind.Relation;

            tmpRightNode.Key = 2;

            tmpRightNode.RelationParams = new List<ExpressionNode>();

            tmpParam = new ExpressionNode();

            tmpRightNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;
            tmpParam.Key = 2;

            NLog.LogManager.GetCurrentClassLogger().Info(tmpRootNode);
        }
    }
}
