using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjVerbObjConditionFinNodeAction(ATNConditionWillSubjVerbObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjVerbObjConditionFinNodeFactory_v2(ATNConditionWillSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjVerbObjConditionFinNodeFactory_v2(ATNConditionWillSubjVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Verb_Obj_Condition_Fin;

        public ATNConditionWillSubjVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjVerbObjConditionFinNodeAction mInitAction;

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

