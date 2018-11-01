using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeBeingConditionV3TransOrFinNodeAction(ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 item);

    public class ATNSubjFToBeBeingConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeBeingConditionV3TransOrFinNodeFactory_v2(ATNSubjFToBeBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeBeingConditionV3TransOrFinNodeFactory_v2(ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeBeingConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeBeingConditionTransNode_v2 mParentNode;
        private ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeBeingConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeBeingConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeBeingConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Being_Condition_V3_Obj_TransOrFin
    Subj_FToBe_Being_Condition_V3_No_Trans
    Subj_FToBe_Being_Condition_V3_Condition_Fin
*/

    public class ATNSubjFToBeBeingConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 sameNode, InitATNSubjFToBeBeingConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Being_Condition_V3_TransOrFin;

        public ATNSubjFToBeBeingConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeBeingConditionV3TransOrFinNodeAction mInitAction;

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

