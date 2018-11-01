using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionV3TransOrFinNodeAction(ATNFToBeSubjConditionV3TransOrFinNode_v2 item);

    public class ATNFToBeSubjConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionV3TransOrFinNodeFactory_v2(ATNFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionV3TransOrFinNodeFactory_v2(ATNFToBeSubjConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionTransNode_v2 mParentNode;
        private ATNFToBeSubjConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Condition_V3_Obj_TransOrFin
    FToBe_Subj_Condition_V3_No_Trans
    FToBe_Subj_Condition_V3_Condition_Fin
*/

    public class ATNFToBeSubjConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionV3TransOrFinNode_v2 sameNode, InitATNFToBeSubjConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_V3_TransOrFin;

        public ATNFToBeSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjConditionV3TransOrFinNodeAction mInitAction;

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

