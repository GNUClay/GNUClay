using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbNotTransNodeAction(ATNSubjModalVerbNotTransNode_v2 item);

    public class ATNSubjModalVerbNotTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbNotTransNodeFactory_v2(ATNSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbNotTransNodeFactory_v2(ATNSubjModalVerbNotTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbNotTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbTransNode_v2 mParentNode;
        private ATNSubjModalVerbNotTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbNotTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbNotTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbNotTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Not_Verb_TransOrFin
    Subj_ModalVerb_Not_Condition_Trans
*/

    public class ATNSubjModalVerbNotTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotTransNode_v2 sameNode, InitATNSubjModalVerbNotTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Not_Trans;

        public ATNSubjModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbNotTransNode_v2 mSameNode;
        private InitATNSubjModalVerbNotTransNodeAction mInitAction;

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

