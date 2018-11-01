using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjModalVerbSubjVerbConditionFinNodeAction(ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2 item);

    public class ATNConditionQWObjModalVerbSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjModalVerbSubjVerbConditionFinNodeFactory_v2(ATNConditionQWObjModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjModalVerbSubjVerbConditionFinNodeFactory_v2(ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjModalVerbSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjModalVerbSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjModalVerbSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2 sameNode, InitATNConditionQWObjModalVerbSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_ModalVerb_Subj_Verb_Condition_Fin;

        public ATNConditionQWObjModalVerbSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjModalVerbSubjVerbConditionFinNodeAction mInitAction;

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

