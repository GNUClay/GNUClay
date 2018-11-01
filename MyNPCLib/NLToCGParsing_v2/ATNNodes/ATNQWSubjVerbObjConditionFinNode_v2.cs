using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjVerbObjConditionFinNodeAction(ATNQWSubjVerbObjConditionFinNode_v2 item);

    public class ATNQWSubjVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjVerbObjConditionFinNodeFactory_v2(ATNQWSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjVerbObjConditionFinNodeFactory_v2(ATNQWSubjVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjVerbObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbObjConditionFinNode_v2 sameNode, InitATNQWSubjVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Verb_Obj_Condition_Fin;

        public ATNQWSubjVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjVerbObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjVerbObjConditionFinNodeAction mInitAction;

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

