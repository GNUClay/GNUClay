using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbNotVerbTransOrFinNodeAction(ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbNotVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbNotVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbNotVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbNotVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbNotTransNode_v2 mParentNode;
        private ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbNotVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Not_Verb_Obj_TransOrFin
    Condition_Subj_ModalVerb_Not_Verb_Condition_Fin
*/

    public class ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbNotVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Not_Verb_TransOrFin;

        public ATNConditionSubjModalVerbNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbNotVerbTransOrFinNodeAction mInitAction;

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

