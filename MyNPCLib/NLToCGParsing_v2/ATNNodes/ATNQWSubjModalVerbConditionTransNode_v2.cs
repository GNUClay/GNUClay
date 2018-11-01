using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbConditionTransNodeAction(ATNQWSubjModalVerbConditionTransNode_v2 item);

    public class ATNQWSubjModalVerbConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbConditionTransNodeFactory_v2(ATNQWSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbConditionTransNodeFactory_v2(ATNQWSubjModalVerbConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjModalVerbTransNode_v2 mParentNode;
        private ATNQWSubjModalVerbConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_ModalVerb_Condition_Verb_TransOrFin
*/

    public class ATNQWSubjModalVerbConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbConditionTransNode_v2 sameNode, InitATNQWSubjModalVerbConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Condition_Trans;

        public ATNQWSubjModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbConditionTransNode_v2 mSameNode;
        private InitATNQWSubjModalVerbConditionTransNodeAction mInitAction;

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

