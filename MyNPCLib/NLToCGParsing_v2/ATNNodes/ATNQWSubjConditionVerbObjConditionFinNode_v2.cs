using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjConditionVerbObjConditionFinNodeAction(ATNQWSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNQWSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjConditionVerbObjConditionFinNodeFactory_v2(ATNQWSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjConditionVerbObjConditionFinNodeFactory_v2(ATNQWSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNQWSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Condition_Verb_Obj_Condition_Fin;

        public ATNQWSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjConditionVerbObjConditionFinNodeAction mInitAction;

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

