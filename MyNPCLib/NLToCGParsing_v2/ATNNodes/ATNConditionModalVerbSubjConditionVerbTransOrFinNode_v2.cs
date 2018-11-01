using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjConditionVerbTransOrFinNodeAction(ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionModalVerbSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjConditionTransNode_v2 mParentNode;
        private ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Condition_Verb_Obj_TransOrFin
    Condition_ModalVerb_Subj_Condition_Verb_No_Trans
    Condition_ModalVerb_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionModalVerbSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Condition_Verb_TransOrFin;

        public ATNConditionModalVerbSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjConditionVerbTransOrFinNodeAction mInitAction;

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

