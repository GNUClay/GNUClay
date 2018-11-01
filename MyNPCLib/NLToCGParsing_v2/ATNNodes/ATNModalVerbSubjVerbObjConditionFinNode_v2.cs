using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjVerbObjConditionFinNodeAction(ATNModalVerbSubjVerbObjConditionFinNode_v2 item);

    public class ATNModalVerbSubjVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjVerbObjConditionFinNodeFactory_v2(ATNModalVerbSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjVerbObjConditionFinNodeFactory_v2(ATNModalVerbSubjVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjVerbObjTransOrFinNode_v2 mParentNode;
        private ATNModalVerbSubjVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNModalVerbSubjVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbObjConditionFinNode_v2 sameNode, InitATNModalVerbSubjVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Verb_Obj_Condition_Fin;

        public ATNModalVerbSubjVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjVerbObjConditionFinNode_v2 mSameNode;
        private InitATNModalVerbSubjVerbObjConditionFinNodeAction mInitAction;

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

