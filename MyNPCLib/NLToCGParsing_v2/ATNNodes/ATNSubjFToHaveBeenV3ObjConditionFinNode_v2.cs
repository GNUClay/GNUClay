using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenV3ObjConditionFinNodeAction(ATNSubjFToHaveBeenV3ObjConditionFinNode_v2 item);

    public class ATNSubjFToHaveBeenV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenV3ObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenV3ObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenV3ObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveBeenV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveBeenV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenV3ObjConditionFinNode_v2 sameNode, InitATNSubjFToHaveBeenV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_V3_Obj_Condition_Fin;

        public ATNSubjFToHaveBeenV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenV3ObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenV3ObjConditionFinNodeAction mInitAction;

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

