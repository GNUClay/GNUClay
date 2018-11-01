using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeVingTransOrFinNodeAction(ATNConditionSubjWillBeVingTransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeVingTransOrFinNodeFactory_v2(ATNConditionSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeVingTransOrFinNodeFactory_v2(ATNConditionSubjWillBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeTransNode_v2 mParentNode;
        private ATNConditionSubjWillBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Ving_Obj_TransOrFin
    Condition_Subj_Will_Be_Ving_No_Trans
    Condition_Subj_Will_Be_Ving_Condition_Fin
*/

    public class ATNConditionSubjWillBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingTransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Ving_TransOrFin;

        public ATNConditionSubjWillBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeVingTransOrFinNodeAction mInitAction;

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

