using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveConditionV3TransOrFinNodeAction(ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2(ATNSubjWillFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2(ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveConditionTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Condition_V3_Obj_TransOrFin
    Subj_Will_FToHave_Condition_V3_No_Trans
    Subj_Will_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNSubjWillFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNSubjWillFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Condition_V3_TransOrFin;

        public ATNSubjWillFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveConditionV3TransOrFinNodeAction mInitAction;

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

