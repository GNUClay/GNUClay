using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveConditionV3NoTransNodeAction(ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2 item);

    public class ATNConditionWillSubjFToHaveConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveConditionV3NoTransNodeFactory_v2(ATNConditionWillSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveConditionV3NoTransNodeFactory_v2(ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_FToHave_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2 sameNode, InitATNConditionWillSubjFToHaveConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_Condition_V3_No_Trans;

        public ATNConditionWillSubjFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveConditionV3NoTransNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveConditionV3NoTransNodeAction mInitAction;

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

