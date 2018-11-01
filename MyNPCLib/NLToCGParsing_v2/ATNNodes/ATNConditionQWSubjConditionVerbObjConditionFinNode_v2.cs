using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjConditionVerbObjConditionFinNodeAction(ATNConditionQWSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjConditionVerbObjConditionFinNodeAction mInitAction;

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

