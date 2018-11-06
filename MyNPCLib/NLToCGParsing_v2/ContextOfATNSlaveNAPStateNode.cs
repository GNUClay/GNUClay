using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ContextOfATNSlaveNAPStateNode
    {
        public void AddNode(ATNSlaveNAPBaseStateNode node)
        {
            mStateNodesStack.Push(node);
        }

        public void RemoveLastElement()
        {
            mStateNodesStack.Pop();
        }

        private Stack<ATNSlaveNAPBaseStateNode> mStateNodesStack = new Stack<ATNSlaveNAPBaseStateNode>();
        public ATNSlaveNAPBaseStateNode CurrentNode
        {
            get
            {
                if(mStateNodesStack.Count == 0)
                {
                    return null;
                }

                return mStateNodesStack.Peek();
            }
        }

        public ContextOfATNSlaveNAPStateNode Fork(ContextOfATNParsing_v2 context)
        {
            var result = new ContextOfATNSlaveNAPStateNode();

            if(mStateNodesStack.Count > 0)
            {
                var sourceList = mStateNodesStack.ToList();

                var destList = new List<ATNSlaveNAPBaseStateNode>();

                foreach(var item in sourceList)
                {
                    destList.Add(item.Fork(context, result));
                }

                destList.Reverse();

                result.mStateNodesStack = new Stack<ATNSlaveNAPBaseStateNode>(destList);
            }

            return result;
        }
    }
}
