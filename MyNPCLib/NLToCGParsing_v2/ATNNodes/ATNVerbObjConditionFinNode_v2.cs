using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbObjConditionFinNodeAction(ATNVerbObjConditionFinNode_v2 item);

    public class ATNVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbObjConditionFinNodeFactory_v2(ATNVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbObjConditionFinNodeFactory_v2(ATNVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNVerbObjTransOrFinNode_v2 mParentNode;
        private ATNVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbObjConditionFinNode_v2 sameNode, InitATNVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_Obj_Condition_Fin;

        public ATNVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNVerbObjConditionFinNode_v2 mSameNode;
        private InitATNVerbObjConditionFinNodeAction mInitAction;

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

