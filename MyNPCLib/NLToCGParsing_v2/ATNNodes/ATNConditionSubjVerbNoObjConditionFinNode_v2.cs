using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjVerbNoObjConditionFinNodeAction(ATNConditionSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Verb_No_Obj_Condition_Fin;

        public ATNConditionSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjVerbNoObjConditionFinNodeAction mInitAction;

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

