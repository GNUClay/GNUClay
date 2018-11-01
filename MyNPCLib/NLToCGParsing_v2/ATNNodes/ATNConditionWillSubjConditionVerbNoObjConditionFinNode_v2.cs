using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjConditionVerbNoObjConditionFinNodeAction(ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionWillSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

