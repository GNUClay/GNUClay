using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeAction(ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillConditionVerbNoObjConditionFinNodeAction mInitAction;

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

