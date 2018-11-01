using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeVingTransOrFinNodeAction(ATNWillSubjBeVingTransOrFinNode_v2 item);

    public class ATNWillSubjBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeVingTransOrFinNodeFactory_v2(ATNWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeVingTransOrFinNodeFactory_v2(ATNWillSubjBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeTransNode_v2 mParentNode;
        private ATNWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_Ving_Obj_TransOrFin
    Will_Subj_Be_Ving_No_Trans
    Will_Subj_Be_Ving_Condition_Fin
*/

    public class ATNWillSubjBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeVingTransOrFinNode_v2 sameNode, InitATNWillSubjBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Ving_TransOrFin;

        public ATNWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjBeVingTransOrFinNodeAction mInitAction;

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

