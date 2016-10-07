using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TSTConsoleWorkBench.LogicalStorage.Insert;
using TSTConsoleWorkBench.LogicalStorage.Select;

namespace TSTConsoleWorkBench
{
    class Program
    {
        static void Main(string[] args)
        {
            TSTRunInsert();
            //TSTStorageDataDictionary();
            //TSTRunSelect();
            //CreateMyFirstExpressionTree();
        }

        private static void TSTRunInsert()
        {
            var tmpLogicalStorageInsertRunner = new LogicalStorageInsertRunner();

            tmpLogicalStorageInsertRunner.Run();
        }

        private static void TSTStorageDataDictionary()
        {
            var tmpStorageDataDictionary = new StorageDataDictionary();

            var tmpStr = "parent";

            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");

            NLog.LogManager.GetCurrentClassLogger().Info($"tmpStorageDataDictionary.UniqueKeysCount() = {tmpStorageDataDictionary.UniqueKeysCount()}");

            tmpStr = "male";

            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"{tmpStr} = {tmpStorageDataDictionary.GetKey(tmpStr)}");

            NLog.LogManager.GetCurrentClassLogger().Info($"tmpStorageDataDictionary.UniqueKeysCount() = {tmpStorageDataDictionary.UniqueKeysCount()}");
        }

        private static void TSTRunSelect()
        {
            var tmpLogicalStorageSelectRunner = new LogicalStorageSelectRunner();

            tmpLogicalStorageSelectRunner.Run();
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
