using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjConditionTransNodeAction(ATNConditionModalVerbSubjConditionTransNode_v2 item);

    public class ATNConditionModalVerbSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjConditionTransNodeFactory_v2(ATNConditionModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjConditionTransNodeFactory_v2(ATNConditionModalVerbSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjTransNode_v2 mParentNode;
        private ATNConditionModalVerbSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Condition_Verb_TransOrFin
*/

    public class ATNConditionModalVerbSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionTransNode_v2 sameNode, InitATNConditionModalVerbSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Condition_Trans;

        public ATNConditionModalVerbSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjConditionTransNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjConditionTransNodeAction mInitAction;

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

