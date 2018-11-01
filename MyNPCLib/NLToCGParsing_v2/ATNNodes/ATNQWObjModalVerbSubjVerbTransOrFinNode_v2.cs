using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjModalVerbSubjVerbTransOrFinNodeAction(ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 item);

    public class ATNQWObjModalVerbSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjModalVerbSubjVerbTransOrFinNodeFactory_v2(ATNQWObjModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjModalVerbSubjVerbTransOrFinNodeFactory_v2(ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjModalVerbSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjModalVerbSubjTransNode_v2 mParentNode;
        private ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjModalVerbSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjModalVerbSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjModalVerbSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_ModalVerb_Subj_Verb_Condition_Fin
*/

    public class ATNQWObjModalVerbSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjModalVerbSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjModalVerbSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 sameNode, InitATNQWObjModalVerbSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_ModalVerb_Subj_Verb_TransOrFin;

        public ATNQWObjModalVerbSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWObjModalVerbSubjVerbTransOrFinNodeAction mInitAction;

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

