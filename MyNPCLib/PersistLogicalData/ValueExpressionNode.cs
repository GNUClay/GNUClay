using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.PersistLogicalData
{
    [Serializable]
    public class ValueExpressionNode : BaseExpressionNode
    {
        public override KindOfExpressionNode Kind => KindOfExpressionNode.Value;
        public override bool IsValue => true;
        public override ValueExpressionNode AsValue => this;
        public object Value { get; set; }
        public KindOfValueType KindOfValueType { get; set; } = KindOfValueType.Unknown;
        
        public override BaseExpressionNode Clone(CloneContextOfPersistLogicalData context)
        {
            var result = new ValueExpressionNode();
            result.Value = Value;
            result.KindOfValueType = KindOfValueType;
            result.Annotations = LogicalAnnotation.CloneListOfAnnotations(Annotations, context);
            return result;
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Value)} = {Value}");
            sb.AppendLine($"{spaces}{nameof(KindOfValueType)} = {KindOfValueType}");
            sb.Append(base.PropertiesToString(n));
            return sb.ToString();
        }

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Value)} = {Value}");
            sb.AppendLine($"{spaces}{nameof(KindOfValueType)} = {KindOfValueType}");
            sb.Append(base.PropertiesToShortString(n));
            return sb.ToString();
        }
    }
}
