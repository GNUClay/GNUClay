using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjBeingTransNodeAction(ATNFToBeSubjBeingTransNode_v2 item);

    public class ATNFToBeSubjBeingTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjBeingTransNodeFactory_v2(ATNFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjBeingTransNodeFactory_v2(ATNFToBeSubjBeingTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjBeingTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjTransNode_v2 mParentNode;
        private ATNFToBeSubjBeingTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjBeingTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjBeingTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjBeingTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Being_V3_TransOrFin
    FToBe_Subj_Being_Condition_Trans
*/

    public class ATNFToBeSubjBeingTransNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingTransNode_v2 sameNode, InitATNFToBeSubjBeingTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Being_Trans;

        public ATNFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjBeingTransNode_v2 mSameNode;
        private InitATNFToBeSubjBeingTransNodeAction mInitAction;

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

