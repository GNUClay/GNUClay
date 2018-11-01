using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeBeingConditionV3NoTransNodeAction(ATNSubjFToBeBeingConditionV3NoTransNode_v2 item);

    public class ATNSubjFToBeBeingConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeBeingConditionV3NoTransNodeFactory_v2(ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeBeingConditionV3NoTransNodeFactory_v2(ATNSubjFToBeBeingConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeBeingConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeBeingConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeBeingConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeBeingConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeBeingConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Being_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNSubjFToBeBeingConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeBeingConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeBeingConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingConditionV3NoTransNode_v2 sameNode, InitATNSubjFToBeBeingConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Being_Condition_V3_No_Trans;

        public ATNSubjFToBeBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeBeingConditionV3NoTransNode_v2 mSameNode;
        private InitATNSubjFToBeBeingConditionV3NoTransNodeAction mInitAction;

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

