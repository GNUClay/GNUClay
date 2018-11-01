using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionConditionVerbObjConditionFinNodeAction(ATNConditionConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionConditionVerbObjConditionFinNodeFactory_v2(ATNConditionConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionConditionVerbObjConditionFinNodeFactory_v2(ATNConditionConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionConditionVerbObjConditionFinNodeAction mInitAction;

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

