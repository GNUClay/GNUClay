using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotV3ObjConditionFinNodeAction(ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeNotV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeNotV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_V3_Obj_Condition_Fin;

        public ATNConditionSubjFToBeNotV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotV3ObjConditionFinNodeAction mInitAction;

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

