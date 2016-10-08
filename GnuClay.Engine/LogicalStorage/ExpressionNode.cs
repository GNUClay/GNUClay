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

        public long GetLongHashCode()
        {
            switch (Kind)
            {
                case ExpressionNodeKind.And:
                    return GetLongAndHashCode();

                case ExpressionNodeKind.Or:
                    return GetLongOrHashCode();

                case ExpressionNodeKind.Not:
                    return GetLongNotHashCode();

                case ExpressionNodeKind.Relation:
                    return GetLongRelationHashCode();

                case ExpressionNodeKind.Var:
                    return GetLongVarHashCode();

                case ExpressionNodeKind.Entity:
                    return GetLongEntityHashCode();

                default: throw new ArgumentOutOfRangeException();
            }
        }

        private long GetLongAndHashCode()
        {
            return (int)Kind * 500 * (Left.GetLongHashCode() + Right.GetLongHashCode());
        }

        private long GetLongOrHashCode()
        {
            return (int)Kind * 400 * (Left.GetLongHashCode() + Right.GetLongHashCode());
        }

        private long GetLongNotHashCode()
        {
            return (int)Kind * 300 * Left.GetLongHashCode();
        }

        private long GetLongRelationHashCode()
        {
            long tmpHashCode = (int)Kind * 200 * Key;

            foreach(var tmpParam in RelationParams)
            {
                tmpHashCode += tmpParam.GetLongHashCode();
            }

            return tmpHashCode;
        }

        private long GetLongVarHashCode()
        {
            return (int)Kind * 100 * Key;
        }

        private long GetLongEntityHashCode()
        {
            return (int)Kind * 10 * Key;
        }

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
