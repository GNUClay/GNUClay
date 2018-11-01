using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillConditionVerbNoObjConditionFinNodeAction(ATNSubjWillConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNSubjWillConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillConditionVerbNoObjConditionFinNodeFactory_v2(ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillConditionVerbNoObjConditionFinNodeFactory_v2(ATNSubjWillConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNSubjWillConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Condition_Verb_No_Obj_Condition_Fin;

        public ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillConditionVerbNoObjConditionFinNodeAction mInitAction;

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

