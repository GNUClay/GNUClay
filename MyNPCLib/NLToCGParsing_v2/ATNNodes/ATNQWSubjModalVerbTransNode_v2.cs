using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbTransNodeAction(ATNQWSubjModalVerbTransNode_v2 item);

    public class ATNQWSubjModalVerbTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbTransNodeFactory_v2(ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbTransNodeFactory_v2(ATNQWSubjModalVerbTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjTransNode_v2 mParentNode;
        private ATNQWSubjModalVerbTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_ModalVerb_Verb_TransOrFin
    QWSubj_ModalVerb_Condition_Trans
*/

    public class ATNQWSubjModalVerbTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbTransNode_v2 sameNode, InitATNQWSubjModalVerbTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Trans;

        public ATNQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbTransNode_v2 mSameNode;
        private InitATNQWSubjModalVerbTransNodeAction mInitAction;

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

