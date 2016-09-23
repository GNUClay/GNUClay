using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    public enum ExpressionNodeKind
    {
        And,
        Or,
        Not,
        Relation,
        Entity,
        Var
    }

    public class ExpressionNode: IToStringData
    {
        public ExpressionNodeKind Kind = ExpressionNodeKind.And;

        /// <summary>
        /// A key of Relation, Entity or Var.
        /// </summary>
        public int Key = 0;

        public ExpressionNode Left = null;
        public ExpressionNode Right = null;

        public List<ExpressionNode> RelationParams = null;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(Kind));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Kind.ToString());

            tmpSb.Append(nameof(Key));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Key.ToString());

            tmpSb.AppendLine(_ObjectHelper._ToString(Left, nameof(Left)));
            tmpSb.AppendLine(_ObjectHelper._ToString(Right, nameof(Right)));

            tmpSb.AppendLine(_ListHelper._ToString(RelationParams, nameof(RelationParams)));

            return tmpSb.ToString();
        }
    }
}
