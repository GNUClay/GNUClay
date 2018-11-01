using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillTransNodeAction(ATNWillTransNode_v2 item);

    public class ATNWillTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillTransNodeFactory_v2(ATNWillTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNWillTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Trans
*/

    public class ATNWillTransNode_v2: BaseATNNode_v2
    {
        public ATNWillTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillTransNode_v2(ContextOfATNParsing_v2 context, ATNWillTransNode_v2 sameNode, InitATNWillTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNWillTransNode_v2 mSameNode;
        private InitATNWillTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

