using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillConditionVerbObjConditionFinNodeAction(ATNConditionSubjWillConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillConditionVerbObjConditionFinNodeAction mInitAction;

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

