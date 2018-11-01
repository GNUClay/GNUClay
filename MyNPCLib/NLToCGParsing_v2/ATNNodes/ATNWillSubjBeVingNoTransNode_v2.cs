using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeVingNoTransNodeAction(ATNWillSubjBeVingNoTransNode_v2 item);

    public class ATNWillSubjBeVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeVingNoTransNodeFactory_v2(ATNWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeVingNoTransNodeFactory_v2(ATNWillSubjBeVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeVingTransOrFinNode_v2 mParentNode;
        private ATNWillSubjBeVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_Ving_No_Obj_TransOrFin
*/

    public class ATNWillSubjBeVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeVingNoTransNode_v2 sameNode, InitATNWillSubjBeVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Ving_No_Trans;

        public ATNWillSubjBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeVingNoTransNode_v2 mSameNode;
        private InitATNWillSubjBeVingNoTransNodeAction mInitAction;

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

