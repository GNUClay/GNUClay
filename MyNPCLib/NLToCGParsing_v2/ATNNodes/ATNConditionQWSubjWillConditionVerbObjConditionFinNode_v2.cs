using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillConditionVerbObjConditionFinNodeAction(ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillConditionVerbObjConditionFinNodeAction mInitAction;

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

