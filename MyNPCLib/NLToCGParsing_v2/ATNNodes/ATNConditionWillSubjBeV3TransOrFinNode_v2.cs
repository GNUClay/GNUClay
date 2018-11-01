using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeV3TransOrFinNodeAction(ATNConditionWillSubjBeV3TransOrFinNode_v2 item);

    public class ATNConditionWillSubjBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeV3TransOrFinNodeFactory_v2(ATNConditionWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeV3TransOrFinNodeFactory_v2(ATNConditionWillSubjBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeTransNode_v2 mParentNode;
        private ATNConditionWillSubjBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_V3_Obj_TransOrFin
    Condition_Will_Subj_Be_V3_No_Trans
    Condition_Will_Subj_Be_V3_Condition_Fin
*/

    public class ATNConditionWillSubjBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeV3TransOrFinNode_v2 sameNode, InitATNConditionWillSubjBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_V3_TransOrFin;

        public ATNConditionWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeV3TransOrFinNodeAction mInitAction;

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

