using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotVerbObjConditionFinNodeAction(ATNConditionSubjWillNotVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Verb_Obj_Condition_Fin;

        public ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotVerbObjConditionFinNodeAction mInitAction;

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

