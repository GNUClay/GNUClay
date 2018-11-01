using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbNoObjConditionFinNodeAction(ATNVerbNoObjConditionFinNode_v2 item);

    public class ATNVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbNoObjConditionFinNodeFactory_v2(ATNVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbNoObjConditionFinNodeFactory_v2(ATNVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbNoObjConditionFinNode_v2 sameNode, InitATNVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_No_Obj_Condition_Fin;

        public ATNVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNVerbNoObjConditionFinNodeAction mInitAction;

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

