using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeVingNoTransNodeAction(ATNConditionSubjWillBeVingNoTransNode_v2 item);

    public class ATNConditionSubjWillBeVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeVingNoTransNodeFactory_v2(ATNConditionSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeVingNoTransNodeFactory_v2(ATNConditionSubjWillBeVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionSubjWillBeVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingNoTransNode_v2 sameNode, InitATNConditionSubjWillBeVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Ving_No_Trans;

        public ATNConditionSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeVingNoTransNode_v2 mSameNode;
        private InitATNConditionSubjWillBeVingNoTransNodeAction mInitAction;

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

