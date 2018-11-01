using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjBeVingTransOrFinNodeAction(ATNQWObjWillSubjBeVingTransOrFinNode_v2 item);

    public class ATNQWObjWillSubjBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjBeVingTransOrFinNodeFactory_v2(ATNQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjBeVingTransOrFinNodeFactory_v2(ATNQWObjWillSubjBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjBeTransNode_v2 mParentNode;
        private ATNQWObjWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_Be_Ving_Condition_Fin
*/

    public class ATNQWObjWillSubjBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeVingTransOrFinNode_v2 sameNode, InitATNQWObjWillSubjBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Be_Ving_TransOrFin;

        public ATNQWObjWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjBeVingTransOrFinNodeAction mInitAction;

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

