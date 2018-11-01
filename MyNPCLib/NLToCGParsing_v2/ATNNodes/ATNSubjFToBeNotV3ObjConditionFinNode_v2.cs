using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotV3ObjConditionFinNodeAction(ATNSubjFToBeNotV3ObjConditionFinNode_v2 item);

    public class ATNSubjFToBeNotV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeNotV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeNotV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotV3ObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotV3ObjConditionFinNode_v2 sameNode, InitATNSubjFToBeNotV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_V3_Obj_Condition_Fin;

        public ATNSubjFToBeNotV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotV3ObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotV3ObjConditionFinNodeAction mInitAction;

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

