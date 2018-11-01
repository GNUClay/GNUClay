using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeAction(ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotBeingConditionTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_Being_Condition_V3_Obj_TransOrFin
    Condition_Subj_FToBe_Not_Being_Condition_V3_Condition_Fin
*/

    public class ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Being_Condition_V3_TransOrFin;

        public ATNConditionSubjFToBeNotBeingConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotBeingConditionV3TransOrFinNodeAction mInitAction;

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

