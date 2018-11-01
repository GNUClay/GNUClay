using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbConditionVerbTransOrFinNodeAction(ATNSubjModalVerbConditionVerbTransOrFinNode_v2 item);

    public class ATNSubjModalVerbConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbConditionTransNode_v2 mParentNode;
        private ATNSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Condition_Verb_Obj_TransOrFin
    Subj_ModalVerb_Condition_Verb_No_Trans
    Subj_ModalVerb_Condition_Verb_Condition_Fin
*/

    public class ATNSubjModalVerbConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, InitATNSubjModalVerbConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Condition_Verb_TransOrFin;

        public ATNSubjModalVerbConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

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

