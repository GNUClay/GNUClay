using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
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
        public ulong Key = 0;

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
        /// Contains Value if Kind = ExpressionNodeKind.Value.
        /// </summary>
        public object Value;

        /// <summary>
        /// A key that represents reference between nodes.
        /// </summary>
        public ulong KeyOfReference;

        /// <summary>
        /// Returns the hash code for this instance. The hashcode has type long and do not override standard GetHashCode().
        /// </summary>
        /// <returns>The hash code for this instance</returns>
        public ulong GetLongHashCode()
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

                case ExpressionNodeKind.Value:
                    return GetLongValueHashCode();

                default: throw new ArgumentOutOfRangeException(nameof(Kind), Kind.ToString());
            }
        }

        private ulong GetLongAndHashCode()
        {
            return (ulong)Kind * 500 * (Left.GetLongHashCode() + Right.GetLongHashCode());
        }

        private ulong GetLongOrHashCode()
        {
            return (ulong)Kind * 400 * (Left.GetLongHashCode() + Right.GetLongHashCode());
        }

        private ulong GetLongNotHashCode()
        {
            return (ulong)Kind * 300 * Left.GetLongHashCode();
        }

        private ulong GetLongRelationHashCode()
        {
            ulong tmpHashCode = (ulong)Kind * 200 * Key;

            foreach(var tmpParam in RelationParams)
            {
                tmpHashCode += tmpParam.GetLongHashCode();
            }

            return tmpHashCode;
        }

        private ulong GetLongVarHashCode()
        {
            return (ulong)Kind * 100 * Key;
        }

        private ulong GetLongEntityHashCode()
        {
            return (ulong)Kind * 10 * Key;
        }

        private ulong GetLongValueHashCode()
        {
            var tmpHash = (ulong)Kind * 10 * Key;

            if(Value != null)
            {
                tmpHash *= (ulong)Value.GetHashCode();
            }

            return tmpHash;
        }

        public bool IsEquals(ExpressionNode item)
        {
            if(item == null)
            {
                return false;
            }

            if(Key != item.Key)
            {
                return false;
            }

            if(Kind != item.Kind)
            {
                return false;
            }

            switch(Kind)
            {
                case ExpressionNodeKind.And:
                    return IsEqualsAndNode(item);

                case ExpressionNodeKind.Or:
                    return IsEqualsOrNode(item);

                case ExpressionNodeKind.Not:
                    return IsEqualsNotNode(item);

                case ExpressionNodeKind.Relation:
                    return IsEqualsRelationNode(item);
            }

            return true;
        }

        private bool IsEqualsAndNode(ExpressionNode item)
        {
            return Left.IsEquals(item.Left) && Right.IsEquals(item.Right);
        }

        private bool IsEqualsOrNode(ExpressionNode item)
        {
            return Left.IsEquals(item.Left) && Right.IsEquals(item.Right);
        }

        private bool IsEqualsNotNode(ExpressionNode item)
        {
            return Left.IsEquals(item.Left);
        }

        private bool IsEqualsRelationNode(ExpressionNode item)
        {
            if(_ListHelper.IsEmpty(RelationParams) && _ListHelper.IsEmpty(item.RelationParams))
            {
                return true;
            }

            if(RelationParams == null && item.RelationParams != null)
            {
                return false;
            }

            if(RelationParams.Count != item.RelationParams.Count)
            {
                return false;
            }

            var selfEnumerator = RelationParams.GetEnumerator();
            var otherEnumerator = item.RelationParams.GetEnumerator();

            while(selfEnumerator.MoveNext())
            {
                otherEnumerator.MoveNext();

                if(!selfEnumerator.Current.IsEquals(otherEnumerator.Current))
                {
                    return false;
                }
            }

            return true;
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

            tmpSb.AppendLine($"{nameof(Kind)} = {Kind}");
            tmpSb.AppendLine($"{nameof(Key)} = {Key}");
            tmpSb.AppendLine($"{nameof(KeyOfReference)} = {KeyOfReference}");
            tmpSb.AppendLine($"{nameof(Value)} = {Value}");
            tmpSb.AppendLine(_ObjectHelper._ToString(Left, nameof(Left)));
            tmpSb.AppendLine(_ObjectHelper._ToString(Right, nameof(Right)));
            tmpSb.AppendLine(_ListHelper._ToString(RelationParams, nameof(RelationParams)));

            return tmpSb.ToString();
        }
    }
}
