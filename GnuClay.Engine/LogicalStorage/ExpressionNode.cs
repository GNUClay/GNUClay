using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    /// <summary>
    /// The kind of some expression node.
    /// </summary>
    public enum ExpressionNodeKind
    {
        /// <summary>
        /// Represents `And` node.
        /// </summary>
        And,

        /// <summary>
        /// Represents `Or` node.
        /// </summary>
        Or,

        /// <summary>
        /// Represents `Not` node.
        /// </summary>
        Not,

        /// <summary>
        /// Represents some relation.
        /// </summary>
        Relation,

        /// <summary>
        /// Represents some entity.
        /// </summary>
        Entity,

        /// <summary>
        /// Represents some variable.
        /// </summary>
        Var
    }

    /// <summary>
    /// The node of some expression.
    /// </summary>
    [Serializable]
    public class ExpressionNode: IToStringData
    {
        /// <summary>
        /// Kind of this node instance.
        /// </summary>
        public ExpressionNodeKind Kind = ExpressionNodeKind.And;

        /// <summary>
        /// A key of Relation, Entity or Var.
        /// </summary>
        public int Key = 0;

        /// <summary>
        /// The node of left branch expression.
        /// </summary>
        public ExpressionNode Left = null;

        /// <summary>
        /// The node of right branch expression.
        /// </summary>
        public ExpressionNode Right = null;

        /// <summary>
        /// Params of relation. Has params if Kind equal ExpressionNodeKind.Relation.
        /// </summary>
        public List<ExpressionNode> RelationParams = null;

        /// <summary>
        /// Returns the hash code for this instance. The hashcode has type long and do not override standard GetHashCode().
        /// </summary>
        /// <returns>The hash code for this instance</returns>
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

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
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
