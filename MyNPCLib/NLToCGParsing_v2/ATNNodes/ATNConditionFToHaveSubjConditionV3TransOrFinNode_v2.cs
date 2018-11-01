using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjConditionV3TransOrFinNodeAction(ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2 item);

    public class ATNConditionFToHaveSubjConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjConditionV3TransOrFinNodeFactory_v2(ATNConditionFToHaveSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjConditionV3TransOrFinNodeFactory_v2(ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjConditionTransNode_v2 mParentNode;
        private ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Condition_V3_Obj_TransOrFin
    Condition_FToHave_Subj_Condition_V3_No_Trans
    Condition_FToHave_Subj_Condition_V3_Condition_Fin
*/

    public class ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2 sameNode, InitATNConditionFToHaveSubjConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Condition_V3_TransOrFin;

        public ATNConditionFToHaveSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjConditionV3TransOrFinNodeAction mInitAction;

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

