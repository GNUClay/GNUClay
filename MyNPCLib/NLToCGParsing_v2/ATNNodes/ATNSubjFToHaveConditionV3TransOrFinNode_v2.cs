using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveConditionV3TransOrFinNodeAction(ATNSubjFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNSubjFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveConditionTransNode_v2 mParentNode;
        private ATNSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Condition_V3_Obj_TransOrFin
    Subj_FToHave_Condition_V3_No_Trans
    Subj_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNSubjFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNSubjFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Condition_V3_TransOrFin;

        public ATNSubjFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

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

