using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjConditionTransNodeAction(ATNModalVerbSubjConditionTransNode_v2 item);

    public class ATNModalVerbSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjConditionTransNodeFactory_v2(ATNModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjConditionTransNodeFactory_v2(ATNModalVerbSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjTransNode_v2 mParentNode;
        private ATNModalVerbSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_Subj_Condition_Verb_TransOrFin
*/

    public class ATNModalVerbSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionTransNode_v2 sameNode, InitATNModalVerbSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Condition_Trans;

        public ATNModalVerbSubjTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjConditionTransNode_v2 mSameNode;
        private InitATNModalVerbSubjConditionTransNodeAction mInitAction;

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

