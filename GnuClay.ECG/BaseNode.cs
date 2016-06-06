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
    public abstract class BaseNode
    {
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
    }
}
