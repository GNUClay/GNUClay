﻿using GnuClay.CommonClientTypes;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class GetPropertyQueryBuilder : BaseQueryBuilder
    {
        public GetPropertyQueryBuilder(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
            : base(context, logicalContext)
        {
        }

        private SelectQuery mResult = null;

        public SelectQuery Run(IValue holder, ulong propertyKey)
        {
            mResult = new SelectQuery();
            var rootExpressionNode = new ExpressionNode();

            mResult.SelectedTree = rootExpressionNode;
            rootExpressionNode.Key = propertyKey;
            rootExpressionNode.Kind = ExpressionNodeKind.Relation;
            var relationParams = new List<ExpressionNode>();
            rootExpressionNode.RelationParams = relationParams;

            throw new NotImplementedException();

            //return mResult;
        }
    }
}
