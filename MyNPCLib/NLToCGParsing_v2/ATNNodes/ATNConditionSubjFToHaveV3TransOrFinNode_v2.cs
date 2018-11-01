using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveV3TransOrFinNodeAction(ATNConditionSubjFToHaveV3TransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveV3TransOrFinNodeFactory_v2(ATNConditionSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveV3TransOrFinNodeFactory_v2(ATNConditionSubjFToHaveV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_V3_Obj_TransOrFin
    Condition_Subj_FToHave_V3_No_Trans
    Condition_Subj_FToHave_V3_Condition_Fin
*/

    public class ATNConditionSubjFToHaveV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveV3TransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_V3_TransOrFin;

        public ATNConditionSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveV3TransOrFinNodeAction mInitAction;

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

