using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbTransNodeAction(ATNSubjModalVerbTransNode_v2 item);

    public class ATNSubjModalVerbTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbTransNodeFactory_v2(ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbTransNodeFactory_v2(ATNSubjModalVerbTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjTransNode_v2 mParentNode;
        private ATNSubjModalVerbTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Verb_TransOrFin
    Subj_ModalVerb_Not_Trans
    Subj_ModalVerb_Condition_Trans
*/

    public class ATNSubjModalVerbTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbTransNode_v2 sameNode, InitATNSubjModalVerbTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Trans;

        public ATNSubjTransNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbTransNode_v2 mSameNode;
        private InitATNSubjModalVerbTransNodeAction mInitAction;

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

