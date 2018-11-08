using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib
{
    public class NPCHandResourcesResolution : BaseNPCResourcesResolution
    {
        public override NPCResourceKind Kind => NPCResourceKind.Hand;
        public INPCCommand Command { get; set; }
        public List<ulong> CurrentProcessesId { get; set; }

        public override NPCHandResourcesResolution ToHandResourcesResulution()
        {
            return this;
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));

            if (Command == null)
            {
                sb.AppendLine($"{spaces}{nameof(Command)} = null");
            }
            else
            {
                sb.Append(Command.ToString(nextN));
            }

            return sb.ToString();
        }
    }
}
