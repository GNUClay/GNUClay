using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.PersistLogicalData
{
    [Serializable]
    public class EntityConditionExpressionNode : BaseRefExpressionNode
    {
        public override KindOfExpressionNode Kind => KindOfExpressionNode.EntityCondition;
        public override bool IsEntityCondition => true;
        public override EntityConditionExpressionNode AsEntityCondition => this;

        public string VariableName { get; set; }
        public ulong VariableKey { get; set; }

        public override BaseExpressionNode Clone(CloneContextOfPersistLogicalData context)
        {
            var result = new EntityConditionExpressionNode();
            FillForClone(result, context);
            return result;
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
            sb.AppendLine($"{spaces}{nameof(VariableName)} = {VariableName}");
            sb.AppendLine($"{spaces}{nameof(Key)} = {Key}");
            return sb.ToString();
        }

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortString(n));
            sb.AppendLine($"{spaces}{nameof(VariableName)} = {VariableName}");
            sb.AppendLine($"{spaces}{nameof(VariableKey)} = {VariableKey}");
            return sb.ToString();
        }
    }
}
