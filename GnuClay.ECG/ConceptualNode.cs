using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.ECG
{
    /// <summary>
    /// Conceptual node of conceptual graph.
    /// </summary>
    [Serializable]
    public class ConceptualNode: BaseNode
    {
        public override bool IsConcept
        {
            get
            {
                return true;
            }
        }

        public string ClassName { get; set; } = string.Empty;

        public override string FullName
        {
            get
            {
                var tmpSb = new StringBuilder();

                if(!string.IsNullOrWhiteSpace(ClassName))
                {
                    tmpSb.Append(ClassName);
                    tmpSb.Append(":");
                }

                if(!string.IsNullOrWhiteSpace(Name))
                {
                    tmpSb.Append(Name);
                }
                
                return tmpSb.ToString();
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

        public void AddChild(BaseNode node)
        {
            if(node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if(mChildren.Contains(node))
            {
                return;
            }

            mChildren.Add(node);

            if(node.Parent != this)
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

            if(node.Parent == this)
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
