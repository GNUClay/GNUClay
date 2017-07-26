using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.CG
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

        public string ClassName
        {
            get
            {
                return mClassName;
            }

            set
            {
                if (value == mClassName)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    mClassName = string.Empty;

                    NCreateName();
                }

                mClassName = value.Trim();

                NCreateName();
            }
        }

        public string InstanceName
        {
            get
            {
                return mInstanceName;
            }

            set
            {
                if (value == mInstanceName)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    mInstanceName = string.Empty;

                    NCreateName();
                }

                mInstanceName = value.Trim();

                NCreateName();
            }
        }

        private void NCreateName()
        {
            if (string.IsNullOrWhiteSpace(mClassName) && string.IsNullOrWhiteSpace(mInstanceName))
            {
                mName = string.Empty;

                return;
            }

            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(mClassName))
            {
                sb.Append(mClassName);

                if (!string.IsNullOrWhiteSpace(mInstanceName))
                {
                    sb.Append(":");
                }
            }

            if (!string.IsNullOrWhiteSpace(mInstanceName))
            {
                sb.Append(mInstanceName);
            }

            mName = sb.ToString().Trim();
        }

        public string Name
        {
            get
            {
                return mName;
            }
        }

        private string mClassName = string.Empty;
        private string mInstanceName = string.Empty;
        private string mName = string.Empty;

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
                if (value == mParent)
                {
                    return;
                }

                if (mParent != null)
                {
                    mParent.RemoveChild(this);
                }

                mParent = value;

                if (mParent != null)
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
            if (mChildren.Contains(node))
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

        public List<CGNode> OutputNodes
        {
            get
            {
                return mOutputNodes;
            }
        }

        public void AddInputNode(CGNode node)
        {
            if (mInputNodes.Contains(node))
            {
                return;
            }

            mInputNodes.Add(node);

            node.AddOutputNode(this);
        }

        public void RemoveInputNode(CGNode node)
        {
            if (!mInputNodes.Contains(node))
            {
                return;
            }

            mInputNodes.Remove(node);

            node.RemoveOutputNode(this);
        }

        public void AddOutputNode(CGNode node)
        {
            if (mOutputNodes.Contains(node))
            {
                return;
            }

            mOutputNodes.Add(node);

            node.AddInputNode(this);
        }

        public void RemoveOutputNode(CGNode node)
        {
            if (!mOutputNodes.Contains(node))
            {
                return;
            }

            mOutputNodes.Remove(node);

            node.RemoveInputNode(this);
        }

        public string ToDbgString()
        {
            return Name;
        }

        public bool IsEquals(CGNode node, List<CGNode> visitedNodes = null)
        {
            if(visitedNodes == null)
            {
                visitedNodes = new List<CGNode>();            
            }
            else
            {
                if(visitedNodes.Contains(this))
                {
                    return true;
                }
            }

            visitedNodes.Add(this);

            if (ClassName != node.ClassName)
            {
                return false;
            }

            if (InstanceName != node.InstanceName)
            {
                return false;
            }

            if (Children == null && node.Children != null)
            {
                return false;
            }

            if (Children.Count != node.Children.Count)
            {
                return false;
            }

            if (OutputNodes == null && node.OutputNodes != null)
            {
                return false;
            }

            if (OutputNodes.Count != node.OutputNodes.Count)
            {
                return false;
            }

            if (InputNodes == null && InputNodes != null)
            {
                return false;
            }

            if (InputNodes.Count != InputNodes.Count)
            {
                return false;
            }

            if (Children.Count > 0)
            {
                var thisChildrenEnumerator = Children.GetEnumerator();
                var otherChildrenEnumerator = node.Children.GetEnumerator();

                while (thisChildrenEnumerator.MoveNext())
                {
                    otherChildrenEnumerator.MoveNext();

                    if (!thisChildrenEnumerator.Current.IsEquals(otherChildrenEnumerator.Current, visitedNodes))
                    {
                        return false;
                    }
                }
            }

            if (OutputNodes.Count > 0)
            {
                var thisOutputNodesEnumerator = OutputNodes.GetEnumerator();
                var otherOutputNodesEnumerator = node.OutputNodes.GetEnumerator();

                while (thisOutputNodesEnumerator.MoveNext())
                {
                    otherOutputNodesEnumerator.MoveNext();

                    if (!thisOutputNodesEnumerator.Current.IsEquals(otherOutputNodesEnumerator.Current, visitedNodes))
                    {
                        return false;
                    }
                }
            }

            if (InputNodes.Count > 0)
            {
                var thisInputNodesEnumerator = InputNodes.GetEnumerator();
                var otherInputNodesEnumerator = node.InputNodes.GetEnumerator();

                while (thisInputNodesEnumerator.MoveNext())
                {
                    otherInputNodesEnumerator.MoveNext();

                    if (!thisInputNodesEnumerator.Current.IsEquals(otherInputNodesEnumerator.Current, visitedNodes))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
