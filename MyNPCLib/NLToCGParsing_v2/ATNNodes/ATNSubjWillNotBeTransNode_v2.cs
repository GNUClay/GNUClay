using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeTransNodeAction(ATNSubjWillNotBeTransNode_v2 item);

    public class ATNSubjWillNotBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeTransNodeFactory_v2(ATNSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeTransNodeFactory_v2(ATNSubjWillNotBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotTransNode_v2 mParentNode;
        private ATNSubjWillNotBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Be_Ving_TransOrFin
    Subj_Will_Not_Be_V3_TransOrFin
    Subj_Will_Not_Be_Condition_Trans
*/

    public class ATNSubjWillNotBeTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeTransNode_v2 sameNode, InitATNSubjWillNotBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Trans;

        public ATNSubjWillNotTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeTransNode_v2 mSameNode;
        private InitATNSubjWillNotBeTransNodeAction mInitAction;

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

