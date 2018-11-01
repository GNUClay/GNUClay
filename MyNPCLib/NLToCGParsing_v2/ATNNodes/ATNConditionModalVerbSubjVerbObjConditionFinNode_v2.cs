using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjVerbObjConditionFinNodeAction(ATNConditionModalVerbSubjVerbObjConditionFinNode_v2 item);

    public class ATNConditionModalVerbSubjVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjVerbObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjVerbObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionModalVerbSubjVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbObjConditionFinNode_v2 sameNode, InitATNConditionModalVerbSubjVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Verb_Obj_Condition_Fin;

        public ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjVerbObjConditionFinNodeAction mInitAction;

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

