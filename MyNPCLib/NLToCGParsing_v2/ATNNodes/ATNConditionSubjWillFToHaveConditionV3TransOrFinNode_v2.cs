using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveConditionV3TransOrFinNodeAction(ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveConditionTransNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_Condition_V3_Obj_TransOrFin
    Condition_Subj_Will_FToHave_Condition_V3_No_Trans
    Condition_Subj_Will_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Condition_V3_TransOrFin;

        public ATNConditionSubjWillFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveConditionV3TransOrFinNodeAction mInitAction;

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

