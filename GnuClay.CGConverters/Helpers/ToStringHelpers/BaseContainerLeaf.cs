using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public abstract class BaseContainerLeaf: BaseLeaf, IBaseContainerLeaf
    {
        protected BaseContainerLeaf(ILeafContext context, IConceptualNode node)
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

        private IConceptualNode mNode = null;

        public IConceptualNode Node
        {
            get
            {
                return mNode;
            }
        }

        protected virtual void PringBegin()
        {
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

        private List<IBaseContainerLeaf> mSubGraphs = null;

        private List<IConceptualLeaf> mConceptions = null;

        private List<IRelationLeaf> mRelations = null;

        private IBaseLeaf mSomeChildLeaf = null;

        public override IBaseLeaf SomeChildLeaf
        {
            get
            {
                return mSomeChildLeaf;
            }
        }

        protected virtual void FillChildren()
        {
            mSubGraphs = new List<IBaseContainerLeaf>();

            mConceptions = new List<IConceptualLeaf>();

            mRelations = new List<IRelationLeaf>();

            var tmpChilNodes = new List<IBaseLeaf>();

            foreach (var node in Node.Children)
            {
                var tmpNode = Context.CreateLeaf(node);

                tmpChilNodes.Add(tmpNode);
            }

            mSomeChildLeaf = tmpChilNodes.FirstOrDefault();

            mSubGraphs = tmpChilNodes.Where(p => p is IBaseContainerLeaf).Select(p => p as IBaseContainerLeaf).ToList();

            mConceptions = tmpChilNodes.Where(p => p is IConceptualLeaf).Select(p => p as IConceptualLeaf).ToList();

            mRelations = tmpChilNodes.Where(p => p is IRelationLeaf).Select(p => p as IRelationLeaf).ToList();
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

        protected virtual void ProcessLink(IBaseLeaf begin, IBaseLeaf end)
        {
        }
    }
}
