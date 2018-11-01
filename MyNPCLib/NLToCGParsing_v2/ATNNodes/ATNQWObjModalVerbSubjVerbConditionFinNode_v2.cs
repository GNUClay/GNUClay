using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjModalVerbSubjVerbConditionFinNodeAction(ATNQWObjModalVerbSubjVerbConditionFinNode_v2 item);

    public class ATNQWObjModalVerbSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjModalVerbSubjVerbConditionFinNodeFactory_v2(ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjModalVerbSubjVerbConditionFinNodeFactory_v2(ATNQWObjModalVerbSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjModalVerbSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNQWObjModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjModalVerbSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjModalVerbSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjModalVerbSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjModalVerbSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjVerbConditionFinNode_v2 sameNode, InitATNQWObjModalVerbSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_ModalVerb_Subj_Verb_Condition_Fin;

        public ATNQWObjModalVerbSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNQWObjModalVerbSubjVerbConditionFinNodeAction mInitAction;

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

