using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeVingTransOrFinNodeAction(ATNConditionSubjWillNotBeVingTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeVingTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeVingTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Be_Ving_Obj_TransOrFin
    Condition_Subj_Will_Not_Be_Ving_Condition_Fin
*/

    public class ATNConditionSubjWillNotBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeVingTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Ving_TransOrFin;

        public ATNConditionSubjWillNotBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeVingTransOrFinNodeAction mInitAction;

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

