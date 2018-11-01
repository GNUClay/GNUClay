using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotConditionV3TransOrFinNodeAction(ATNSubjFToHaveNotConditionV3TransOrFinNode_v2 item);

    public class ATNSubjFToHaveNotConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotConditionV3TransOrFinNodeFactory_v2(ATNSubjFToHaveNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotConditionV3TransOrFinNodeFactory_v2(ATNSubjFToHaveNotConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotConditionTransNode_v2 mParentNode;
        private ATNSubjFToHaveNotConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Not_Condition_V3_Obj_TransOrFin
    Subj_FToHave_Not_Condition_V3_Condition_Fin
*/

    public class ATNSubjFToHaveNotConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotConditionV3TransOrFinNode_v2 sameNode, InitATNSubjFToHaveNotConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Condition_V3_TransOrFin;

        public ATNSubjFToHaveNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotConditionV3TransOrFinNodeAction mInitAction;

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

