﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser.DOT
{
    public abstract class BaseContainerLeaf: BaseLeaf
    {
        protected BaseContainerLeaf(DotContext context, CGNode node)
            : base(context)
        {
            mNode = node;
            Name = Context.GetClusterName();
            Context.RegLeaf(mNode, this);
        }

        public override bool IsContainer
        {
            get
            {
                return true;
            }
        }

        private CGNode mNode = null;

        public CGNode Node
        {
            get
            {
                return mNode;
            }
        }

        protected virtual void PringBegin()
        {
            Sb.Append("digraph ");
            Sb.Append(Name);
            Sb.AppendLine("{");
            Sb.AppendLine("compound=true;");
        }

        protected virtual void PrintEnd()
        {
            Sb.AppendLine("}");
        }

        protected override void OnRun()
        {
            FillChildren();

            PringBegin();

            ProcessConcepts();
            ProcessRelations();
            ProcessSubGraphs();

            ProcessLinks();

            PrintEnd();
        }

        private List<BaseContainerLeaf> mSubGraphs = null;

        private List<ConceptualLeaf> mConceptions = null;

        private List<RelationLeaf> mRelations = null;

        private BaseLeaf mSomeChildLeaf = null;

        public override BaseLeaf SomeChildLeaf
        {
            get
            {
                return mSomeChildLeaf;
            }
        }

        protected virtual void FillChildren()
        {
            mSubGraphs = new List<BaseContainerLeaf>();

            mConceptions = new List<ConceptualLeaf>();

            mRelations = new List<RelationLeaf>();

            var tmpChilNodes = new List<BaseLeaf>();

            foreach (var node in Node.Children)
            {
                var tmpNode = Context.CreateLeaf(node);

                tmpChilNodes.Add(tmpNode);
            }

            mSomeChildLeaf = tmpChilNodes.FirstOrDefault();

            mSubGraphs = tmpChilNodes.Where(p => p is BaseContainerLeaf).Select(p => p as BaseContainerLeaf).ToList();

            mConceptions = tmpChilNodes.Where(p => p is ConceptualLeaf).Select(p => p as ConceptualLeaf).ToList();

            mRelations = tmpChilNodes.Where(p => p is RelationLeaf).Select(p => p as RelationLeaf).ToList();
        }

        protected virtual void ProcessConcepts()
        {
            foreach (var leaf in mConceptions)
            {
                leaf.Run();

                Sb.AppendLine(leaf.Text);
            }
        }

        protected virtual void ProcessRelations()
        {
            foreach (var leaf in mRelations)
            {
                leaf.Run();

                Sb.AppendLine(leaf.Text);
            }
        }

        protected virtual void ProcessSubGraphs()
        {
            foreach (var leaf in mSubGraphs)
            {
                leaf.Run();

                Sb.AppendLine(leaf.Text);
            }
        }

        protected virtual void ProcessLinks()
        {
            var tmpOutPutLists = Node.Children.Where(p => p.OutputNodes.Count > 0).ToList();

            foreach (var node in tmpOutPutLists)
            {
                var tmpLeaf = Context.GetLeaf(node);

                foreach (var second in node.OutputNodes)
                {
                    var tmpSecondLeaf = Context.GetLeaf(second);

                    ProcessLink(tmpLeaf, tmpSecondLeaf);
                }
            }
        }

        protected virtual void ProcessLink(BaseLeaf begin, BaseLeaf end)
        {
            if (begin.IsContainer)
            {
                Sb.Append(begin.SomeChildLeaf.Name);
            }
            else
            {
                Sb.Append(begin.Name);
            }

            Sb.Append(" -> ");

            if (end.IsContainer)
            {
                Sb.Append(end.SomeChildLeaf.Name);
            }
            else
            {
                Sb.Append(end.Name);
            }

            if (begin.IsContainer || end.IsContainer)
            {
                Sb.Append("[");

                if (begin.IsContainer)
                {
                    Sb.Append("ltail=");
                    Sb.Append(begin.Name);
                    Sb.Append(",");
                }

                if (end.IsContainer)
                {
                    Sb.Append("lhead=");
                    Sb.Append(end.Name);
                }

                Sb.Append("]");
            }

            Sb.AppendLine(";");
        }
    }
}
