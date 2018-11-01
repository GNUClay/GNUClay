using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjConditionVerbObjConditionFinNodeAction(ATNConditionWillSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionWillSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjConditionVerbObjConditionFinNodeAction mInitAction;

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

