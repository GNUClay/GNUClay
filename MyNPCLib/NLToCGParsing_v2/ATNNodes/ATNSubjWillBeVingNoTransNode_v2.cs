using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeVingNoTransNodeAction(ATNSubjWillBeVingNoTransNode_v2 item);

    public class ATNSubjWillBeVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeVingNoTransNodeFactory_v2(ATNSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeVingNoTransNodeFactory_v2(ATNSubjWillBeVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_Ving_No_Obj_TransOrFin
*/

    public class ATNSubjWillBeVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingNoTransNode_v2 sameNode, InitATNSubjWillBeVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Ving_No_Trans;

        public ATNSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeVingNoTransNode_v2 mSameNode;
        private InitATNSubjWillBeVingNoTransNodeAction mInitAction;

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

