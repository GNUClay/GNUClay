using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionV3NoTransNodeAction(ATNFToBeSubjConditionV3NoTransNode_v2 item);

    public class ATNFToBeSubjConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionV3NoTransNodeFactory_v2(ATNFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionV3NoTransNodeFactory_v2(ATNFToBeSubjConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionV3TransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNFToBeSubjConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionV3NoTransNode_v2 sameNode, InitATNFToBeSubjConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_V3_No_Trans;

        public ATNFToBeSubjConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionV3NoTransNode_v2 mSameNode;
        private InitATNFToBeSubjConditionV3NoTransNodeAction mInitAction;

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

