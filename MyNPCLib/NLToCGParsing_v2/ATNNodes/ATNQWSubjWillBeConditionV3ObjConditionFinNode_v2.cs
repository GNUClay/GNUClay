using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeConditionV3ObjConditionFinNodeAction(ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2 item);

    public class ATNQWSubjWillBeConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2 sameNode, InitATNQWSubjWillBeConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Condition_V3_Obj_Condition_Fin;

        public ATNQWSubjWillBeConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeConditionV3ObjConditionFinNodeAction mInitAction;

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

