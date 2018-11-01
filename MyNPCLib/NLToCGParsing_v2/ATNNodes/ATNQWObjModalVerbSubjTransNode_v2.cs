using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjModalVerbSubjTransNodeAction(ATNQWObjModalVerbSubjTransNode_v2 item);

    public class ATNQWObjModalVerbSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjModalVerbSubjTransNodeFactory_v2(ATNQWObjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjModalVerbSubjTransNodeFactory_v2(ATNQWObjModalVerbSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjModalVerbSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjModalVerbTransNode_v2 mParentNode;
        private ATNQWObjModalVerbSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjModalVerbSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjModalVerbSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjModalVerbSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_ModalVerb_Subj_Verb_TransOrFin
    QWObj_ModalVerb_Subj_Condition_Trans
*/

    public class ATNQWObjModalVerbSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjModalVerbSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjModalVerbSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjTransNode_v2 sameNode, InitATNQWObjModalVerbSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_ModalVerb_Subj_Trans;

        public ATNQWObjModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjModalVerbSubjTransNode_v2 mSameNode;
        private InitATNQWObjModalVerbSubjTransNodeAction mInitAction;

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

