﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser.DOT
{
    public class RootGraphDotLeaf: BaseContainerLeaf
    {
        public RootGraphDotLeaf(DotContext context, CGNode node)
            : base(context, node)
        {
        }

        protected override void PringBegin()
        {
            Sb.Append("digraph ");
            Sb.Append(Name);
            Sb.AppendLine("{");
            Sb.AppendLine("compound=true;");
        }
    }
}
