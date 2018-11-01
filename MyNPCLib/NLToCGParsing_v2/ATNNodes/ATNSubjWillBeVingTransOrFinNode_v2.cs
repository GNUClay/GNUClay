using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeVingTransOrFinNodeAction(ATNSubjWillBeVingTransOrFinNode_v2 item);

    public class ATNSubjWillBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeVingTransOrFinNodeFactory_v2(ATNSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeVingTransOrFinNodeFactory_v2(ATNSubjWillBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeTransNode_v2 mParentNode;
        private ATNSubjWillBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_Ving_Obj_TransOrFin
    Subj_Will_Be_Ving_No_Trans
    Subj_Will_Be_Ving_Condition_Fin
*/

    public class ATNSubjWillBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingTransOrFinNode_v2 sameNode, InitATNSubjWillBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Ving_TransOrFin;

        public ATNSubjWillBeTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillBeVingTransOrFinNodeAction mInitAction;

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

