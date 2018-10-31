using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public delegate void InitANTSubjTransNodeAction(ANTSubjTransNode_v2 item);

    public class ANTSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ANTSubjTransNodeFactory_v2(ATNInitNode_v2 parentNode)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
        }

        public ANTSubjTransNodeFactory_v2(ANTSubjTransNode_v2 sameNode, InitANTSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ANTSubjTransNode_v2 mSameNode;
        private InitANTSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ANTSubjTransNode_v2(context, mParentNode);

                case 2:
                    return new ANTSubjTransNode_v2(context, mSameNode, mInitAction);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ANTSubjTransNode_v2: BaseATNNode_v2
    {
        public ANTSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode)
            : base(context)
        {
            ParentNode = parentNode;
        }

        public ANTSubjTransNode_v2(ContextOfATNParsing_v2 context, ANTSubjTransNode_v2 sameNode, InitANTSubjTransNodeAction initAction)
            : base(context)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
        }

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ANTSubjTransNode_v2 mSameNode;
        private InitANTSubjTransNodeAction mInitAction;
    }
}
