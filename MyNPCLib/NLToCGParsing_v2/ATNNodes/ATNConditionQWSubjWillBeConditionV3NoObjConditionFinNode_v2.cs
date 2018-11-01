using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeAction(ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Condition_V3_No_Obj_Condition_Fin;

        public ATNConditionQWSubjWillBeConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeConditionV3NoObjConditionFinNodeAction mInitAction;

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

