using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ICG
{
    public class ConceptualNode : BaseNode, IConceptualNode
    {
        public ConceptualNode()
        {
        }

        public ConceptualNode(ConceptualNode parent)
            : base(parent)
        {
        }

        public override bool IsConcept
        {
            get
            {
                return true;
            }
        }

        public string ClassName
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        private List<BaseNode> mChildren = new List<BaseNode>();

        public IList<BaseNode> Children
        {
            get
            {
                return mChildren;
            }
        }

        IList<INode> IConceptualNode.Children
        {
            get
            {
                return mChildren.Cast<INode>().ToList();
            }
        }

        public void AddChild(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (mChildren.Contains(node))
            {
                return;
            }

            mChildren.Add(node);

            if (node.Parent != this)
            {
                node.Parent = this;
            }
        }

        public void RemoveChild(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (!mChildren.Contains(node))
            {
                return;
            }

            mChildren.Remove(node);

            if (node.Parent == this)
            {
                node.Parent = null;
            }
        }

        private const string ErrorMessageTwoConceptsJoinedDirectly = "Two concepts do not join directly. Use relations for joining these concepts.";

        private void CheckArgument(BaseNode node)
        {
            if (node != null && node.IsConcept)
            {
                throw new ArgumentException(ErrorMessageTwoConceptsJoinedDirectly, nameof(node));
            }
        }

        public override void AddInputNode(BaseNode node)
        {
            CheckArgument(node);

            base.AddInputNode(node);
        }

        public override void AddOutputNode(BaseNode node)
        {
            CheckArgument(node);

            base.AddOutputNode(node);
        }
    }
}
