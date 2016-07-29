﻿using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ICG
{
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

        public ulong Key { get; set; } = 0;

        public string Name
        {
            get
            {
                return Key.ToString();
            }

            set
            {
                Key = ulong.Parse(value);
            }
        }

        public virtual string FullName
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
                if (mParent == value)
                {
                    return;
                }

                var tmpOldParent = mParent;

                mParent = value;

                if (tmpOldParent != null)
                {
                    tmpOldParent.RemoveChild(this);
                }

                if (mParent != null)
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

            if (mInputNodes.Contains(node))
            {
                return;
            }

            mInputNodes.Add(node);

            node.AddOutputNode(this);
        }

        void INode.AddInputNode(INode node)
        {
            AddInputNode((BaseNode)node);
        }

        public virtual void RemoveInputNode(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (!mInputNodes.Contains(node))
            {
                return;
            }

            mInputNodes.Remove(node);

            node.RemoveOutputNode(this);
        }

        void INode.RemoveInputNode(INode node)
        {
            RemoveInputNode((BaseNode)node);
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

            if (mOutputNodes.Contains(node))
            {
                return;
            }

            mOutputNodes.Add(node);

            node.AddInputNode(this);
        }

        void INode.AddOutputNode(INode node)
        {
            AddOutputNode((BaseNode)node);
        }

        public virtual void RemoveOutputNode(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (!mOutputNodes.Contains(node))
            {
                return;
            }

            mOutputNodes.Remove(node);

            node.RemoveInputNode(this);
        }

        void INode.RemoveOutputNode(INode node)
        {
            RemoveOutputNode((BaseNode)node);
        }

        public QuantificationInfo Quantification { get; set; } = QuantificationInfo.None;

        public bool HasQuestion { get; set; } = false;

        public bool HasVar { get; set; } = false;
    }
}
