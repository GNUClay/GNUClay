using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.PersistLogicalData
{
    [Serializable]
    public abstract class BinaryOperatorExpressionNode : BaseExpressionNode
    {
        public override bool IsBinaryOperator => true;
        public override BinaryOperatorExpressionNode AsBinaryOperator => this;

        public BaseExpressionNode Left { get; set; }
        public BaseExpressionNode Right { get; set; }
        
        protected void FillForClone(BinaryOperatorExpressionNode dest, CloneContextOfPersistLogicalData context)
        {
            dest.Left = Left.Clone(context);
            dest.Right = Right.Clone(context);
            dest.Annotations = LogicalAnnotation.CloneListOfAnnotations(Annotations, context);
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
            if (Left == null)
            {
                sb.AppendLine($"{spaces}{nameof(Left)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin{nameof(Left)}");
                sb.Append(Left.PropertiesToShortString(nextN));
                sb.AppendLine($"{spaces}End{nameof(Left)}");
            }
            if (Right == null)
            {
                sb.AppendLine($"{spaces}{nameof(Right)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin{nameof(Right)}");
                sb.Append(Right.PropertiesToShortString(nextN));
                sb.AppendLine($"{spaces}End{nameof(Right)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortString(n));
            if (Left == null)
            {
                sb.AppendLine($"{spaces}{nameof(Left)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin{nameof(Left)}");
                sb.Append(Left.PropertiesToShortString(nextN));
                sb.AppendLine($"{spaces}End{nameof(Left)}");
            }

            if (Right == null)
            {
                sb.AppendLine($"{spaces}{nameof(Right)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin{nameof(Right)}");
                sb.Append(Right.PropertiesToShortString(nextN));
                sb.AppendLine($"{spaces}End{nameof(Right)}");
            }
            return sb.ToString();
        }
    }
}
