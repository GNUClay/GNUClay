using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.ECG
{
    /// <summary>
    /// This node is base for both ConceptualNode and RelationNode.
    /// This class implements the connection to the base node-concept. 
    /// </summary>
    [Serializable]
    public abstract class BaseNode: INode
    {
        protected BaseNode()
        {
        }

        protected BaseNode(ConceptualNode parent)
        {
            Parent = parent;
        }

        public virtual bool IsConcept
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsRelation
        {
            get
            {
                return false;
            }
        }

        public string Name { get; set; } = string.Empty;

        public virtual string FullName
        {
            get
            {
                return Name;
            }
        }

        private ConceptualNode mParent = null;

        /// <summary>
        /// The base node-concept for concepts and relations in this sentence.
        ///Often it is pure virtual node.
        ///But sometimes it is a some usual node-concept in other sentences(metasentences for this sentence).
        /// </summary>
        public ConceptualNode Parent
        {
            get
            {
                return mParent;
            }

            set
            {
                if(mParent == value)
                {
                    return;
                }

                var tmpOldParent = mParent;

                mParent = value;

                if(tmpOldParent != null)
                {
                    tmpOldParent.RemoveChild(this);
                }

                if(mParent != null)
                {
                    mParent.AddChild(this);
                }
            }
        }

        IConceptualNode INode.Parent
        {
            get
            {
                return mParent;
            }
        }

        private List<ConceptualNode> mAnnotations = new List<ConceptualNode>();

        public IList<ConceptualNode> Annotations
        {
            get
            {
                return mAnnotations;
            }
        }

        IList<IConceptualNode> INode.Annotations
        {
            get
            {
                return mAnnotations.Cast<IConceptualNode>().ToList();
            }
        }

        public void AddAnnotation(ConceptualNode annotation)
        {
            if(annotation == null)
            {
                throw new ArgumentNullException(nameof(annotation));
            }

            if(mAnnotations.Contains(annotation))
            {
                return;
            }

            mAnnotations.Add(annotation);
        }

        public void RemoveAnnotation(ConceptualNode annotation)
        {
            if (annotation == null)
            {
                throw new ArgumentNullException(nameof(annotation));
            }

            if (!mAnnotations.Contains(annotation))
            {
                return;
            }

            mAnnotations.Remove(annotation);
        }

        private List<BaseNode> mInputNodes = new List<BaseNode>();

        public IList<BaseNode> InputNodes
        {
            get
            {
                return mInputNodes;
            }
        }

        IList<INode> INode.InputNodes
        {
            get
            {
                return mInputNodes.Cast<INode>().ToList();
            }
        }

        public virtual void AddInputNode(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if(mInputNodes.Contains(node))
            {
                return;
            }

            mInputNodes.Add(node);

            node.AddOutputNode(this);
        }

        public virtual void RemoveInputNode(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if(!mInputNodes.Contains(node))
            {
                return;
            }

            mInputNodes.Remove(node);

            node.RemoveOutputNode(this);
        }

        private List<BaseNode> mOutputNodes = new List<BaseNode>();

        public IList<BaseNode> OutputNodes
        {
            get
            {
                return mOutputNodes;
            }
        }

        IList<INode> INode.OutputNodes
        {
            get
            {
                return mOutputNodes.Cast<INode>().ToList();
            }
        }

        public virtual void AddOutputNode(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if(mOutputNodes.Contains(node))
            {
                return;
            }

            mOutputNodes.Add(node);

            node.AddInputNode(this);
        }

        public virtual void RemoveOutputNode(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if(!mOutputNodes.Contains(node))
            {
                return;
            }

            mOutputNodes.Remove(node);

            node.RemoveInputNode(this);
        }
    }
}
