using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class CGNode
    {
        public CGNode()
        {
        }

        public CGNode(CGNode parent)
        {
            Parent = parent;
        }

        public string ClassName = string.Empty;
        public string InstanceName = string.Empty;

        public CGNodeKind Kind = CGNodeKind.Undefined;

        private CGNode mParent = null;
        private List<CGNode> mChildren = new List<CGNode>();

        public CGNode Parent
        {
            get
            {
                return mParent;
            }

            set
            {
                if(value == mParent)
                {
                    return;
                }

                if(mParent != null)
                {
                    mParent.RemoveChild(this);
                }

                mParent = value;

                if(mParent != null)
                {
                    mParent.AddChild(this);
                }
            }
        }

        public List<CGNode> Children
        {
            get
            {
                return mChildren;
            }
        }

        protected void AddChild(CGNode node)
        {
            if(mChildren.Contains(node))
            {
                return;
            }

            mChildren.Add(node);
        }

        protected void RemoveChild(CGNode node)
        {
            if (mChildren.Contains(node))
            {
                return;
            }

            mChildren.Remove(node);
        }

        private List<CGNode> mInputNodes = new List<CGNode>();
        private List<CGNode> mOutputNodes = new List<CGNode>();

        public List<CGNode> InputNodes
        {
            get
            {
                return mInputNodes;
            }
        }

        public List
    }
}
