using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotConditionV3TransOrFinNodeAction(ATNSubjFToBeNotConditionV3TransOrFinNode_v2 item);

    public class ATNSubjFToBeNotConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotConditionV3TransOrFinNodeFactory_v2(ATNSubjFToBeNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotConditionV3TransOrFinNodeFactory_v2(ATNSubjFToBeNotConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotConditionTransNode_v2 mParentNode;
        private ATNSubjFToBeNotConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Not_Condition_V3_Obj_TransOrFin
    Subj_FToBe_Not_Condition_V3_Condition_Fin
*/

    public class ATNSubjFToBeNotConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionV3TransOrFinNode_v2 sameNode, InitATNSubjFToBeNotConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Condition_V3_TransOrFin;

        public ATNSubjFToBeNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotConditionV3TransOrFinNodeAction mInitAction;

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

