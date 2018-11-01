using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjConditionVerbNoObjConditionFinNodeAction(ATNConditionSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

