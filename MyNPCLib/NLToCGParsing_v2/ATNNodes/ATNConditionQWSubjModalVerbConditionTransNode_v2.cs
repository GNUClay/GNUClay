using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbConditionTransNodeAction(ATNConditionQWSubjModalVerbConditionTransNode_v2 item);

    public class ATNConditionQWSubjModalVerbConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbConditionTransNodeFactory_v2(ATNConditionQWSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbConditionTransNodeFactory_v2(ATNConditionQWSubjModalVerbConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbTransNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Condition_Verb_TransOrFin
*/

    public class ATNConditionQWSubjModalVerbConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionTransNode_v2 sameNode, InitATNConditionQWSubjModalVerbConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Condition_Trans;

        public ATNConditionQWSubjModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbConditionTransNodeAction mInitAction;

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

