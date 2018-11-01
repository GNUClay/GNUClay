using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeTransNodeAction(ATNWillSubjBeTransNode_v2 item);

    public class ATNWillSubjBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeTransNodeFactory_v2(ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeTransNodeFactory_v2(ATNWillSubjBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjTransNode_v2 mParentNode;
        private ATNWillSubjBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_Ving_TransOrFin
    Will_Subj_Be_V3_TransOrFin
    Will_Subj_Be_Condition_Trans
*/

    public class ATNWillSubjBeTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeTransNode_v2 sameNode, InitATNWillSubjBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Trans;

        public ATNWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeTransNode_v2 mSameNode;
        private InitATNWillSubjBeTransNodeAction mInitAction;

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

