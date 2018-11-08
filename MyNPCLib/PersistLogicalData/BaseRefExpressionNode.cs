using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.PersistLogicalData
{
    [Serializable]
    public abstract class BaseRefExpressionNode: BaseExpressionNode, IRefToRecord
    {
        public string Name { get; set; }
        public ulong Key { get; set; }
        public override bool IsBaseRef => true;
        public override BaseRefExpressionNode AsBaseRef => this;

        public void FillForClone(BaseRefExpressionNode dest, CloneContextOfPersistLogicalData context)
        {
            dest.Name = Name;
            dest.Key = Key;
            dest.Annotations = LogicalAnnotation.CloneListOfAnnotations(Annotations, context);
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
            sb.AppendLine($"{spaces}{nameof(Name)} = {Name}");
            sb.AppendLine($"{spaces}{nameof(Key)} = {Key}");
            return sb.ToString();
        }

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortString(n));
            sb.AppendLine($"{spaces}{nameof(Name)} = {Name}");
            sb.AppendLine($"{spaces}{nameof(Key)} = {Key}");
            return sb.ToString();
        }
    }
}
