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
    }
}
