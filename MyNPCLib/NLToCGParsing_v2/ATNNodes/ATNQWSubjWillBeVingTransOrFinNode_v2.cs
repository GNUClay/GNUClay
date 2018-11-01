using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeVingTransOrFinNodeAction(ATNQWSubjWillBeVingTransOrFinNode_v2 item);

    public class ATNQWSubjWillBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeVingTransOrFinNodeFactory_v2(ATNQWSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeVingTransOrFinNodeFactory_v2(ATNQWSubjWillBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeTransNode_v2 mParentNode;
        private ATNQWSubjWillBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Be_Ving_Obj_TransOrFin
    QWSubj_Will_Be_Ving_No_Trans
    QWSubj_Will_Be_Ving_Condition_Fin
*/

    public class ATNQWSubjWillBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeVingTransOrFinNode_v2 sameNode, InitATNQWSubjWillBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Ving_TransOrFin;

        public ATNQWSubjWillBeTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeVingTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeVingTransOrFinNodeAction mInitAction;

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

