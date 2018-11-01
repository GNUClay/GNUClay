using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjBeingV3NoTransNodeAction(ATNFToBeSubjBeingV3NoTransNode_v2 item);

    public class ATNFToBeSubjBeingV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjBeingV3NoTransNodeFactory_v2(ATNFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjBeingV3NoTransNodeFactory_v2(ATNFToBeSubjBeingV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjBeingV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjBeingV3TransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjBeingV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjBeingV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjBeingV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjBeingV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Being_V3_No_Obj_TransOrFin
*/

    public class ATNFToBeSubjBeingV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingV3NoTransNode_v2 sameNode, InitATNFToBeSubjBeingV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Being_V3_No_Trans;

        public ATNFToBeSubjBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjBeingV3NoTransNode_v2 mSameNode;
        private InitATNFToBeSubjBeingV3NoTransNodeAction mInitAction;

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

