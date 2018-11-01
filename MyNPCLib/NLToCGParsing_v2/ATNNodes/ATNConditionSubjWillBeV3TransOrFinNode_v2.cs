using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeV3TransOrFinNodeAction(ATNConditionSubjWillBeV3TransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeV3TransOrFinNodeFactory_v2(ATNConditionSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeV3TransOrFinNodeFactory_v2(ATNConditionSubjWillBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeTransNode_v2 mParentNode;
        private ATNConditionSubjWillBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_V3_Obj_TransOrFin
    Condition_Subj_Will_Be_V3_No_Trans
    Condition_Subj_Will_Be_V3_Condition_Fin
*/

    public class ATNConditionSubjWillBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeV3TransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_V3_TransOrFin;

        public ATNConditionSubjWillBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeV3TransOrFinNodeAction mInitAction;

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

