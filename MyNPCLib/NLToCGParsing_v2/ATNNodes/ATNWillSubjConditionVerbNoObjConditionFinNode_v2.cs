using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjConditionVerbNoObjConditionFinNodeAction(ATNWillSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNWillSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNWillSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNWillSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

