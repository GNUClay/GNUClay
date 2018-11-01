using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeAction(ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbNotConditionTransNode_v2 mParentNode;
        private ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Not_Condition_Verb_Obj_TransOrFin
    Condition_Subj_ModalVerb_Not_Condition_Verb_Condition_Fin
*/

    public class ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Not_Condition_Verb_TransOrFin;

        public ATNConditionSubjModalVerbNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbNotConditionVerbTransOrFinNodeAction mInitAction;

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

