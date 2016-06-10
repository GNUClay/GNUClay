using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public abstract class BaseContainerDotLeaf : DotBaseLeaf
    {
        protected BaseContainerDotLeaf(DotContext context, IConceptualNode node)
            :base(context)
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

        private IConceptualNode mNode = null;

        protected IConceptualNode Node
        {
            get
            {
                return mNode;
            }
        }

        private List<BaseContainerDotLeaf> mSubGraphs = null;

        private List<ConceptualDotLeaf> mConceptions = null;

        private List<RelationDotLeaf> mRelations = null;

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

        private DotBaseLeaf mSomeChildLeaf = null;

        public override DotBaseLeaf SomeChildLeaf
        {
            get
            {
                return mSomeChildLeaf;
            }
        }

        private void FillChildren()
        {
            mSubGraphs = new List<BaseContainerDotLeaf>();

            mConceptions = new List<ConceptualDotLeaf>();

            mRelations = new List<RelationDotLeaf>();

            var tmpChilNodes = new List<DotBaseLeaf>();

            foreach(var node in Node.Children)
            {
                var tmpNode = Context.CreateLeaf(node);

                tmpChilNodes.Add(tmpNode);
            }

            mSomeChildLeaf = tmpChilNodes.FirstOrDefault();

            mSubGraphs = tmpChilNodes.Where(p => p is BaseContainerDotLeaf).Select(p => p as BaseContainerDotLeaf).ToList();

            mConceptions = tmpChilNodes.Where(p => p is ConceptualDotLeaf).Select(p => p as ConceptualDotLeaf).ToList();

            mRelations = tmpChilNodes.Where(p => p is RelationDotLeaf).Select(p => p as RelationDotLeaf).ToList();
        }

        protected virtual void PringBegin()
        {
            Sb.Append("digraph ");
            Sb.Append(Name);
            Sb.AppendLine("{");
            Sb.AppendLine("compound=true;");
        }

        private void PrintEnd()
        {
            Sb.AppendLine("}");
        }

        private void ProcessConcepts()
        {
            foreach(var leaf in mConceptions)
            {
                leaf.Run();

                Sb.AppendLine(leaf.Text);
            }
        }

        private void ProcessRelations()
        {
            foreach (var leaf in mRelations)
            {
                leaf.Run();

                Sb.AppendLine(leaf.Text);
            }
        }

        private void ProcessSubGraphs()
        {
            foreach (var leaf in mSubGraphs)
            {
                leaf.Run();

                Sb.AppendLine(leaf.Text);
            }
        }

        private void ProcessLinks()
        {
            var tmpOutPutLists = Node.Children.Where(p => p.OutputNodes.Count > 0).ToList();

            foreach(var node in tmpOutPutLists)
            {            
                var tmpLeaf = Context.GetLeaf(node);

                foreach (var second in node.OutputNodes)
                {
                    var tmpSecondLeaf = Context.GetLeaf(second);

                    if (tmpLeaf.IsContainer)
                    {
                        Sb.Append(tmpLeaf.SomeChildLeaf.Name);
                    }
                    else
                    {
                        Sb.Append(tmpLeaf.Name);
                    }

                    Sb.Append(" -> ");

                    if (tmpSecondLeaf.IsContainer)
                    {
                        Sb.Append(tmpSecondLeaf.SomeChildLeaf.Name);
                    }
                    else
                    {
                        Sb.Append(tmpSecondLeaf.Name);
                    }

                    if(tmpLeaf.IsContainer || tmpSecondLeaf.IsContainer)
                    {
                        Sb.Append("[");

                        if(tmpLeaf.IsContainer)
                        {
                            Sb.Append("ltail=");
                            Sb.Append(tmpLeaf.Name);
                            Sb.Append(",");
                        }

                        if(tmpSecondLeaf.IsContainer)
                        {
                            Sb.Append("lhead=");
                            Sb.Append(tmpSecondLeaf.Name);
                        }

                        Sb.Append("]");
                    }

                    Sb.AppendLine(";");
                }
            }
        }
    }
}
