using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeV3NoTransNodeAction(ATNConditionSubjWillBeV3NoTransNode_v2 item);

    public class ATNConditionSubjWillBeV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeV3NoTransNodeFactory_v2(ATNConditionSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeV3NoTransNodeFactory_v2(ATNConditionSubjWillBeV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_V3_No_Obj_TransOrFin
*/

    public class ATNConditionSubjWillBeV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeV3NoTransNode_v2 sameNode, InitATNConditionSubjWillBeV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_V3_No_Trans;

        public ATNConditionSubjWillBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeV3NoTransNode_v2 mSameNode;
        private InitATNConditionSubjWillBeV3NoTransNodeAction mInitAction;

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

