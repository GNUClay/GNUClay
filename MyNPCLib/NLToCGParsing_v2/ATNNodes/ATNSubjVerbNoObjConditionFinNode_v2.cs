using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjVerbNoObjConditionFinNodeAction(ATNSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjVerbNoObjConditionFinNodeFactory_v2(ATNSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjVerbNoObjConditionFinNodeFactory_v2(ATNSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Verb_No_Obj_Condition_Fin;

        public ATNSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjVerbNoObjConditionFinNodeAction mInitAction;

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

