using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbConditionVerbTransOrFinNodeAction(ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbConditionTransNode_v2 mParentNode;
        private ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Condition_Verb_Obj_TransOrFin
    Condition_Subj_ModalVerb_Condition_Verb_No_Trans
    Condition_Subj_ModalVerb_Condition_Verb_Condition_Fin
*/

    public class ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Condition_Verb_TransOrFin;

        public ATNConditionSubjModalVerbConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

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

