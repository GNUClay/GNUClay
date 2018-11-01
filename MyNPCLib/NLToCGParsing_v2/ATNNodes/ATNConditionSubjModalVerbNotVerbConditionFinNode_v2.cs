using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbNotVerbConditionFinNodeAction(ATNConditionSubjModalVerbNotVerbConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbNotVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbNotVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbNotVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbNotVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbNotVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbNotVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbNotVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbNotVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbNotVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbNotVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotVerbConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbNotVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Not_Verb_Condition_Fin;

        public ATNConditionSubjModalVerbNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbNotVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbNotVerbConditionFinNodeAction mInitAction;

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

