using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbVerbConditionFinNodeAction(ATNConditionSubjModalVerbVerbConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Verb_Condition_Fin;

        public ATNConditionSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbVerbConditionFinNodeAction mInitAction;

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

