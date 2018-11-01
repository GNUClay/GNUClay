using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjVerbNoObjConditionFinNodeAction(ATNWillSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNWillSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjVerbNoObjConditionFinNodeFactory_v2(ATNWillSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjVerbNoObjConditionFinNodeFactory_v2(ATNWillSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNWillSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Verb_No_Obj_Condition_Fin;

        public ATNWillSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjVerbNoObjConditionFinNodeAction mInitAction;

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

