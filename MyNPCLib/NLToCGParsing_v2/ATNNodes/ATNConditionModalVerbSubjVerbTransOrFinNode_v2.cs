using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjVerbTransOrFinNodeAction(ATNConditionModalVerbSubjVerbTransOrFinNode_v2 item);

    public class ATNConditionModalVerbSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjVerbTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjVerbTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjTransNode_v2 mParentNode;
        private ATNConditionModalVerbSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Verb_Obj_TransOrFin
    Condition_ModalVerb_Subj_Verb_No_Trans
    Condition_ModalVerb_Subj_Verb_Condition_Fin
*/

    public class ATNConditionModalVerbSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbTransOrFinNode_v2 sameNode, InitATNConditionModalVerbSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Verb_TransOrFin;

        public ATNConditionModalVerbSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjVerbTransOrFinNodeAction mInitAction;

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

