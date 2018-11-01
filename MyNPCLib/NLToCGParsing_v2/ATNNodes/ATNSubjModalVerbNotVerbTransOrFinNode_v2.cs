using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbNotVerbTransOrFinNodeAction(ATNSubjModalVerbNotVerbTransOrFinNode_v2 item);

    public class ATNSubjModalVerbNotVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbNotVerbTransOrFinNodeFactory_v2(ATNSubjModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbNotVerbTransOrFinNodeFactory_v2(ATNSubjModalVerbNotVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbNotVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbNotTransNode_v2 mParentNode;
        private ATNSubjModalVerbNotVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbNotVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbNotVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbNotVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Not_Verb_Obj_TransOrFin
    Subj_ModalVerb_Not_Verb_Condition_Fin
*/

    public class ATNSubjModalVerbNotVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotVerbTransOrFinNode_v2 sameNode, InitATNSubjModalVerbNotVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Not_Verb_TransOrFin;

        public ATNSubjModalVerbNotTransNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbNotVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjModalVerbNotVerbTransOrFinNodeAction mInitAction;

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

