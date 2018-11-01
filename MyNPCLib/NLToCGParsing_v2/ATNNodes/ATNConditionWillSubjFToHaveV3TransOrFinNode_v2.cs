using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveV3TransOrFinNodeAction(ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveV3TransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveV3TransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_FToHave_V3_Obj_TransOrFin
    Condition_Will_Subj_FToHave_V3_No_Trans
    Condition_Will_Subj_FToHave_V3_Condition_Fin
*/

    public class ATNConditionWillSubjFToHaveV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_V3_TransOrFin;

        public ATNConditionWillSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveV3TransOrFinNodeAction mInitAction;

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

