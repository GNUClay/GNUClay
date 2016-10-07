﻿using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    public class RuleInstance : IToStringData
    {
        public RulePart Part_1 = null;
        public RulePart Part_2 = null;

        public int VarsCount = 0;

        public Dictionary<int, ExpressionNode> LocalRelationsIndex = new Dictionary<int, ExpressionNode>();

        private int mHasheCode = 0;

        public void CalculateHashCode()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("CalculateHashCode");
        }

        public override int GetHashCode()
        {
            return mHasheCode;
        }

        public void IndexRelationNode(ExpressionNode node)
        {
            LocalRelationsIndex[node.Key] = node;
        }

        public ExpressionNode GetRealationNodeByKey(int key)
        {
            return LocalRelationsIndex[key];
        }

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(VarsCount));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(VarsCount.ToString());

            tmpSb.AppendLine(_ObjectHelper._ToString(Part_1, nameof(Part_1)));
            tmpSb.AppendLine(_ObjectHelper._ToString(Part_2, nameof(Part_2)));

            return tmpSb.ToString();
        }
    }
}
