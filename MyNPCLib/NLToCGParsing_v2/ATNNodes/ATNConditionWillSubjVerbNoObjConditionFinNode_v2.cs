using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjVerbNoObjConditionFinNodeAction(ATNConditionWillSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Verb_No_Obj_Condition_Fin;

        public ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjVerbNoObjConditionFinNodeAction mInitAction;

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

