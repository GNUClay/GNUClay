using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjBeingConditionTransNodeAction(ATNFToBeSubjBeingConditionTransNode_v2 item);

    public class ATNFToBeSubjBeingConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjBeingConditionTransNodeFactory_v2(ATNFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjBeingConditionTransNodeFactory_v2(ATNFToBeSubjBeingConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjBeingConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjBeingTransNode_v2 mParentNode;
        private ATNFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjBeingConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjBeingConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjBeingConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Being_Condition_V3_TransOrFin
*/

    public class ATNFToBeSubjBeingConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingConditionTransNode_v2 sameNode, InitATNFToBeSubjBeingConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Being_Condition_Trans;

        public ATNFToBeSubjBeingTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private InitATNFToBeSubjBeingConditionTransNodeAction mInitAction;

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

