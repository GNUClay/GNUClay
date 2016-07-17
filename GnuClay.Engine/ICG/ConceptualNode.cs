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

        [Obsolete("Setter is not still implemented")]
        public override string FullName
        {
            get
            {
                var tmpSb = new StringBuilder();

                if(IsInstance)
                {
                    tmpSb.Append("#");
                }

                if(HasQuestion)
                {
                    tmpSb.Append("?");
                }

                switch(Quantification)
                {
                    case QuantificationInfo.Existential:
                        tmpSb.Append("∃");
                        break;

                    case QuantificationInfo.Universal:
                        tmpSb.Append("∀");
                        break;
                }

                tmpSb.Append(Name);

                return base.FullName;
            }
        
            set
            {
                throw new NotImplementedException();
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

        /// <summary>
        /// Additional information for this node.
        /// For example, if ECG node contains number "123.34", then his ICG-equivalent will be instance of number concept, which contains "123.34" in this property.
        /// </summary>
        public object Value { get; set; } = null;

        public QuantificationInfo Quantification { get; set; } = QuantificationInfo.Universal;

        public bool HasQuestion { get; set; } = false;

        public bool IsInstance { get; set; } = false;
    }
}
