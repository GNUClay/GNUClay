using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjVerbTransOrFinNodeAction(ATNModalVerbSubjVerbTransOrFinNode_v2 item);

    public class ATNModalVerbSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjVerbTransOrFinNodeFactory_v2(ATNModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjVerbTransOrFinNodeFactory_v2(ATNModalVerbSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjTransNode_v2 mParentNode;
        private ATNModalVerbSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_Subj_Verb_Obj_TransOrFin
    ModalVerb_Subj_Verb_No_Trans
    ModalVerb_Subj_Verb_Condition_Fin
*/

    public class ATNModalVerbSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbTransOrFinNode_v2 sameNode, InitATNModalVerbSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Verb_TransOrFin;

        public ATNModalVerbSubjTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNModalVerbSubjVerbTransOrFinNodeAction mInitAction;

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

