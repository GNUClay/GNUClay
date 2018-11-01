using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjBeingV3TransOrFinNodeAction(ATNConditionFToBeSubjBeingV3TransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjBeingV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjBeingV3TransOrFinNodeFactory_v2(ATNConditionFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjBeingV3TransOrFinNodeFactory_v2(ATNConditionFToBeSubjBeingV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjBeingV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjBeingTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjBeingV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjBeingV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjBeingV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjBeingV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Being_V3_Obj_TransOrFin
    Condition_FToBe_Subj_Being_V3_No_Trans
    Condition_FToBe_Subj_Being_V3_Condition_Fin
*/

    public class ATNConditionFToBeSubjBeingV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingV3TransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjBeingV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Being_V3_TransOrFin;

        public ATNConditionFToBeSubjBeingTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjBeingV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjBeingV3TransOrFinNodeAction mInitAction;

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

