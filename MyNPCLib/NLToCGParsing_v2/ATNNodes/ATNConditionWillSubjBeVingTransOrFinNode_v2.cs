using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeVingTransOrFinNodeAction(ATNConditionWillSubjBeVingTransOrFinNode_v2 item);

    public class ATNConditionWillSubjBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeVingTransOrFinNodeFactory_v2(ATNConditionWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeVingTransOrFinNodeFactory_v2(ATNConditionWillSubjBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeTransNode_v2 mParentNode;
        private ATNConditionWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_Ving_Obj_TransOrFin
    Condition_Will_Subj_Be_Ving_No_Trans
    Condition_Will_Subj_Be_Ving_Condition_Fin
*/

    public class ATNConditionWillSubjBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingTransOrFinNode_v2 sameNode, InitATNConditionWillSubjBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Ving_TransOrFin;

        public ATNConditionWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeVingTransOrFinNodeAction mInitAction;

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

