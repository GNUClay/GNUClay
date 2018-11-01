using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjBeingConditionV3TransOrFinNodeAction(ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2(ATNConditionFToBeSubjBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2(ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjBeingConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjBeingConditionTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjBeingConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Being_Condition_V3_Obj_TransOrFin
    Condition_FToBe_Subj_Being_Condition_V3_No_Trans
    Condition_FToBe_Subj_Being_Condition_V3_Condition_Fin
*/

    public class ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjBeingConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Being_Condition_V3_TransOrFin;

        public ATNConditionFToBeSubjBeingConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjBeingConditionV3TransOrFinNodeAction mInitAction;

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

