﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib
{
    public class NPCInternalCommand : IObjectToString
    {
        public ulong Key { get; set; }
        public ulong InitiatingProcessId { get; set; }
        public KindOfLinkingToInitiator KindOfLinkingToInitiator { get; set; } = KindOfLinkingToInitiator.Standalone;
        public float Priority { get; set; } = NPCProcessPriorities.Normal;
        public Dictionary<ulong, object> Params { get; set; } = new Dictionary<ulong, object>();

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Key)} = {Key}");
            sb.AppendLine($"{spaces}{nameof(InitiatingProcessId)} = {InitiatingProcessId}");
            sb.AppendLine($"{spaces}{nameof(KindOfLinkingToInitiator)} = {KindOfLinkingToInitiator}");
            sb.AppendLine($"{spaces}{nameof(Priority)} = {Priority}");
            if (Params == null)
            {
                sb.AppendLine($"{spaces}{nameof(Params)} = null");
            }
            else
            {
                var nextN = n + 4;
                var nextSpaces = StringHelper.Spaces(nextN);
                sb.AppendLine($"{spaces}Begin{nameof(Params)}");
                foreach (var paramItem in Params)
                {
                    sb.AppendLine($"{nextSpaces}ParamName = {paramItem.Key}; ParamValue = {paramItem.Value}");
                }
                sb.AppendLine($"{spaces}End{nameof(Params)}");
            }
            return sb.ToString();
        }
    }
}
