using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionConditionVerbNoObjConditionFinNodeAction(ATNConditionConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionConditionVerbNoObjConditionFinNodeAction mInitAction;

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

