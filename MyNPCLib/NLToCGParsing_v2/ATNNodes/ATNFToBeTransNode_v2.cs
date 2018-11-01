using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeTransNodeAction(ATNFToBeTransNode_v2 item);

    public class ATNFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeTransNodeFactory_v2(ATNFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Trans
*/

    public class ATNFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeTransNode_v2 sameNode, InitATNFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNFToBeTransNode_v2 mSameNode;
        private InitATNFToBeTransNodeAction mInitAction;

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

