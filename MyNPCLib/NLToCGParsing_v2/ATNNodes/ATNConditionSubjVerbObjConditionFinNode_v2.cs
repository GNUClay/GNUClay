using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjVerbObjConditionFinNodeAction(ATNConditionSubjVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjVerbObjConditionFinNodeFactory_v2(ATNConditionSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjVerbObjConditionFinNodeFactory_v2(ATNConditionSubjVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Verb_Obj_Condition_Fin;

        public ATNConditionSubjVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjVerbObjConditionFinNodeAction mInitAction;

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

