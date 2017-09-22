using GnuClay.CommonClientTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage;
using System;
using System.Collections.Generic;
using TSTConsoleWorkBench.Actors;
using TSTConsoleWorkBench.CommonTST;
using TSTConsoleWorkBench.LocalHostExecuting;
using TSTConsoleWorkBench.LogicalStorage.Insert;
using TSTConsoleWorkBench.OOP;
using TSTConsoleWorkBench.ParserExecuting;
using TSTConsoleWorkBench.ScriptExecuting;
using TSTConsoleWorkBench.Serialiazation;
using TSTConsoleWorkBench.TextCGParser;

namespace TSTConsoleWorkBench
{
    class Program
    {
        static void Main(string[] args)
        {
            TSTCompilerRunner();
            //TstActorsRunner();
            //TextCGParserRunner();
            //TSTGnuClayLocalServerInheritanceSelectQueryRunner();
            //TSTGnuClayLocalServerInheritanceQueryRunner();
            //TSTGnuClayLocalServerValueQueryRunner();
            //TSTGnuClayLocalServerSerializationRunner();
            //TSTEntityConnectionSerializationRunner();
            //TSTSerializationRunner();
            //TSTLocalHostRunner();
            //TSTParserRunner();//<==
            //TSTCommonRunner();
            //TSTInitialRunner();//<==
            //TSTRunInsert();//<==
            //TSTStorageDataDictionary();
            //CreateMyFirstExpressionTree();
        }

        private static void TSTCompilerRunner()
        {
            var tmpCompilerRunner = new CompilerRunner();
            tmpCompilerRunner.Run();
        }

        private static void TstActorsRunner()
        {
            var tmpTstActorsRunner = new TstActorsRunner();
            tmpTstActorsRunner.Run();
        }

        private static void TextCGParserRunner()
        {
            var tmpTextCGParserRunner = new TextCGParserRunner();
            //tmpTextCGParserRunner.CreateATNStateTree();
            tmpTextCGParserRunner.Run();
            //tmpTextCGParserRunner.TstCG();
        }

        private static void TSTGnuClayLocalServerInheritanceSelectQueryRunner()
        {
            var tmpGnuClayLocalServerInheritanceSelectQueryRunner = new GnuClayLocalServerInheritanceSelectQueryRunner();
            tmpGnuClayLocalServerInheritanceSelectQueryRunner.Run();
        }

        private static void TSTGnuClayLocalServerInheritanceQueryRunner()
        {
            var tmpGnuClayLocalServerInheritanceQueryRunner = new GnuClayLocalServerInheritanceQueryRunner();
            tmpGnuClayLocalServerInheritanceQueryRunner.Run();
        }

        private static void TSTGnuClayLocalServerValueQueryRunner()
        {
            var tmpGnuClayLocalServerValueQueryRunner = new GnuClayLocalServerValueQueryRunner();
            tmpGnuClayLocalServerValueQueryRunner.Run();
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

            tmpStr = "male";

            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");
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
