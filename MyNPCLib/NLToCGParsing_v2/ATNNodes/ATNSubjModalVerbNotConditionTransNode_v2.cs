using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbNotConditionTransNodeAction(ATNSubjModalVerbNotConditionTransNode_v2 item);

    public class ATNSubjModalVerbNotConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbNotConditionTransNodeFactory_v2(ATNSubjModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbNotConditionTransNodeFactory_v2(ATNSubjModalVerbNotConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbNotConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbNotTransNode_v2 mParentNode;
        private ATNSubjModalVerbNotConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbNotConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbNotConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbNotConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Not_Condition_Verb_TransOrFin
*/

    public class ATNSubjModalVerbNotConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbNotConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbNotConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotConditionTransNode_v2 sameNode, InitATNSubjModalVerbNotConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Not_Condition_Trans;

        public ATNSubjModalVerbNotTransNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbNotConditionTransNode_v2 mSameNode;
        private InitATNSubjModalVerbNotConditionTransNodeAction mInitAction;

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

