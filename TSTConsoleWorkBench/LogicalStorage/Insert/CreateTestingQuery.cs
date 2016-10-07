using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.LogicalStorage.Insert
{
    public class CreateTestingQuery
    {
        public CreateTestingQuery(StorageDataDictionary storageDataDictionary)
        {
            mStorageDataDictionary = storageDataDictionary;
        }

        private InsertQuery mInsertQuery = null;

        private StorageDataDictionary mStorageDataDictionary = null;

        public InsertQuery Run()
        {
            mInsertQuery = new InsertQuery();

            CreateRule_1();
            CreateRule_2();
            CreateRule_3();
            CreateRule_4();
            CreateRule_5();
            CreateRule_6();
            CreateRule_7();

            return mInsertQuery;
        }

        private void CreateRule_1()
        {
            //>: {parent($X, $Y)} -> {child($Y, $X)}

            var tmpStorageDataDictionary = new StorageDataDictionary();

            var tmpRule = new RuleInstance();
            mInsertQuery.Items.Add(tmpRule);

            var tmpRulePart_1 = new RulePart();

            tmpRule.Part_1 = tmpRulePart_1;

            tmpRulePart_1.Parent = tmpRule;

            var tmpRulePart_2 = new RulePart();

            tmpRule.Part_2 = tmpRulePart_2;

            tmpRulePart_2.Parent = tmpRule;

            tmpRulePart_1.Next = tmpRulePart_2;
            tmpRulePart_2.Next = tmpRulePart_1;

            //---- tmpRulePart_1  ----
            //{ parent($X, $Y)}

            var tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart_1.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("parent");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$X");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$Y");

            //---- tmpRulePart_2  ----
            //{child($Y, $X)}

            tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart_2.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("child");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$Y");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$X");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpRule);

            NLog.LogManager.GetCurrentClassLogger().Info(RuleInstanceDebugHelper.ConvertToString(tmpRule, mStorageDataDictionary));
        }

        private void CreateRule_2()
        {
            //>: {son($X, $Y)} -> {child($X, $Y) & male($X)}

            var tmpStorageDataDictionary = new StorageDataDictionary();

            var tmpRule = new RuleInstance();
            mInsertQuery.Items.Add(tmpRule);

            var tmpRulePart_1 = new RulePart();

            tmpRule.Part_1 = tmpRulePart_1;

            tmpRulePart_1.Parent = tmpRule;

            var tmpRulePart_2 = new RulePart();

            tmpRule.Part_2 = tmpRulePart_2;

            tmpRulePart_2.Parent = tmpRule;

            tmpRulePart_1.Next = tmpRulePart_2;
            tmpRulePart_2.Next = tmpRulePart_1;

            //---- tmpRulePart_1  ----
            //{son($X, $Y)}

            var tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart_1.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("son");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$X");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$Y");
            //---- tmpRulePart_2  ----
            //{child($X, $Y) & male($X)}

            tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart_2.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.And;

            var tmpLeftNode = new ExpressionNode();

            tmpRootExpressionNode.Left = tmpLeftNode;

            tmpLeftNode.Kind = ExpressionNodeKind.Relation;

            tmpLeftNode.RelationParams = new List<ExpressionNode>();

            tmpLeftNode.Key = mStorageDataDictionary.GetKey("child");

            tmpRule.IndexRelationNode(tmpLeftNode);

            tmpParam = new ExpressionNode();
            tmpLeftNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$X");

            tmpParam = new ExpressionNode();
            tmpLeftNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$Y");

            var tmpRightNode = new ExpressionNode();

            tmpRootExpressionNode.Right = tmpRightNode;

            tmpRightNode.Kind = ExpressionNodeKind.Relation;

            tmpRightNode.Key = mStorageDataDictionary.GetKey("male");

            tmpRule.IndexRelationNode(tmpRightNode);

            tmpRightNode.RelationParams = new List<ExpressionNode>();

            tmpParam = new ExpressionNode();
            tmpRightNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$X");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpRule);

            NLog.LogManager.GetCurrentClassLogger().Info(RuleInstanceDebugHelper.ConvertToString(tmpRule, mStorageDataDictionary));
        }

        private void CreateRule_3()
        {
            //>: {parent(Tom, Piter)}

            var tmpRule = new RuleInstance();
            mInsertQuery.Items.Add(tmpRule);

            var tmpRulePart = new RulePart();

            tmpRule.Part_1 = tmpRulePart;

            tmpRulePart.Parent = tmpRule;

            var tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("parent");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Tom");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Piter");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpRule);

            NLog.LogManager.GetCurrentClassLogger().Info(RuleInstanceDebugHelper.ConvertToString(tmpRule, mStorageDataDictionary));
        }

        private void CreateRule_4()
        {
            //>: {parent(Tom, Mary)}

            var tmpRule = new RuleInstance();
            mInsertQuery.Items.Add(tmpRule);

            var tmpRulePart = new RulePart();

            tmpRule.Part_1 = tmpRulePart;

            tmpRulePart.Parent = tmpRule;

            var tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("parent");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Tom");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Mary");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpRule);

            NLog.LogManager.GetCurrentClassLogger().Info(RuleInstanceDebugHelper.ConvertToString(tmpRule, mStorageDataDictionary));
        }

        private void CreateRule_5()
        {
            //>: {male(Piter)}

            var tmpRule = new RuleInstance();
            mInsertQuery.Items.Add(tmpRule);

            var tmpRulePart = new RulePart();

            tmpRule.Part_1 = tmpRulePart;

            tmpRulePart.Parent = tmpRule;

            var tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("male");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Piter");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpRule);

            NLog.LogManager.GetCurrentClassLogger().Info(RuleInstanceDebugHelper.ConvertToString(tmpRule, mStorageDataDictionary));
        }

        private void CreateRule_6()
        {
            //>: {female(Mary)}

            var tmpRule = new RuleInstance();
            mInsertQuery.Items.Add(tmpRule);

            var tmpRulePart = new RulePart();

            tmpRule.Part_1 = tmpRulePart;

            tmpRulePart.Parent = tmpRule;

            var tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("female");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Mary");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpRule);

            NLog.LogManager.GetCurrentClassLogger().Info(RuleInstanceDebugHelper.ConvertToString(tmpRule, mStorageDataDictionary));
        }

        private void CreateRule_7()
        {
            //>: {male(Bob)}

            var tmpRule = new RuleInstance();
            mInsertQuery.Items.Add(tmpRule);

            var tmpRulePart = new RulePart();

            tmpRule.Part_1 = tmpRulePart;

            tmpRulePart.Parent = tmpRule;

            var tmpRootExpressionNode = new ExpressionNode();

            tmpRulePart.Tree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("male");

            tmpRule.IndexRelationNode(tmpRootExpressionNode);

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Bob");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpRule);

            NLog.LogManager.GetCurrentClassLogger().Info(RuleInstanceDebugHelper.ConvertToString(tmpRule, mStorageDataDictionary));
        }
    }
}
