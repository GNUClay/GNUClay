using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib
{
    public class HumanoidHandsActionStateCommand : HumanoidBodyCommand, IHumanoidHandsActionStateCommand
    {
        public override HumanoidBodyCommandKind Kind => HumanoidBodyCommandKind.HandsActionState;
        public HumanoidHandsActionState State { get; set; }

        public override string ToString()
        {
            return ToString(0u);
        }

        public override string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
            sb.AppendLine($"{spaces}{nameof(State)} = {State}");
            return sb.ToString();
        }
    }
}
