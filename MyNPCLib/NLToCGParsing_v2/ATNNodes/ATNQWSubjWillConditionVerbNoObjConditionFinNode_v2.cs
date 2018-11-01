using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillConditionVerbNoObjConditionFinNodeAction(ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNQWSubjWillConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillConditionVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjWillConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillConditionVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNQWSubjWillConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Condition_Verb_No_Obj_Condition_Fin;

        public ATNQWSubjWillConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillConditionVerbNoObjConditionFinNodeAction mInitAction;

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

