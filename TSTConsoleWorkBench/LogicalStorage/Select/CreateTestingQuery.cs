using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.LogicalStorage.Select
{
    public class CreateTestingQuery
    {
        public CreateTestingQuery(StorageDataDictionary dataDictionary)
        {
            mStorageDataDictionary = dataDictionary;
        }

        private StorageDataDictionary mStorageDataDictionary = null;

        public SelectQuery Run()
        {
            //SELECT {son(Piter, $X)}

            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var tmpStorageDataDictionary = new StorageDataDictionary();

            var tmpQuery = new SelectQuery();

            var tmpRootExpressionNode = new ExpressionNode();

            tmpQuery.SelectedTree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("son");

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Piter");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$X");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpQuery);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectQueryDebugHelper.ConvertToString(tmpQuery, mStorageDataDictionary, null));

            return tmpQuery;
        }

        public SelectQuery RunCase_2()
        {
            //SELECT {son(Piter, Tom)}

            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var tmpStorageDataDictionary = new StorageDataDictionary();

            var tmpQuery = new SelectQuery();

            var tmpRootExpressionNode = new ExpressionNode();

            tmpQuery.SelectedTree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("son");

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Piter");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = mStorageDataDictionary.GetKey("Tom");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpQuery);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectQueryDebugHelper.ConvertToString(tmpQuery, mStorageDataDictionary, null));

            return tmpQuery;
        }

        public SelectQuery RunCase_3()
        {
            //SELECT {son(Piter, Tom)}

            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var tmpStorageDataDictionary = new StorageDataDictionary();

            var tmpQuery = new SelectQuery();

            var tmpRootExpressionNode = new ExpressionNode();

            tmpQuery.SelectedTree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = mStorageDataDictionary.GetKey("son");

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$X");

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = tmpStorageDataDictionary.GetKey("$Y");

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpQuery);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectQueryDebugHelper.ConvertToString(tmpQuery, mStorageDataDictionary, null));

            return tmpQuery;
        }
    }
}
