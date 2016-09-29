using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.LogicalStorage.Select
{
    public class CreateTestingQuery
    {
        public SelectQuery Run()
        {
            //SELECT {son(Piter, $X)}
            //Global data dictionary:
            //parent - 1;
            //child - 2;
            //son - 3;
            //male - 4;
            //female - 5;
            //Tom - 6;
            //Piter - 7;
            //Mary - 8;

            //Variables data dictionary:
            //$X - 1;

            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var tmpQuery = new SelectQuery();

            var tmpRootExpressionNode = new ExpressionNode();

            tmpQuery.SelectedTree = tmpRootExpressionNode;

            tmpRootExpressionNode.Kind = ExpressionNodeKind.Relation;

            tmpRootExpressionNode.Key = 3;

            tmpRootExpressionNode.RelationParams = new List<ExpressionNode>();

            var tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Entity;

            tmpParam.Key = 7;

            tmpParam = new ExpressionNode();
            tmpRootExpressionNode.RelationParams.Add(tmpParam);

            tmpParam.Kind = ExpressionNodeKind.Var;

            tmpParam.Key = 1;

            //NLog.LogManager.GetCurrentClassLogger().Info(tmpQuery);

            return tmpQuery;
        }
    }
}
