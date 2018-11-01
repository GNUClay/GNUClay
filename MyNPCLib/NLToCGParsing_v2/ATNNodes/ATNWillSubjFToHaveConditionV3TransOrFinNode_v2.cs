using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveConditionV3TransOrFinNodeAction(ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNWillSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveConditionTransNode_v2 mParentNode;
        private ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Condition_V3_Obj_TransOrFin
    Will_Subj_FToHave_Condition_V3_No_Trans
    Will_Subj_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNWillSubjFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNWillSubjFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Condition_V3_TransOrFin;

        public ATNWillSubjFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

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

