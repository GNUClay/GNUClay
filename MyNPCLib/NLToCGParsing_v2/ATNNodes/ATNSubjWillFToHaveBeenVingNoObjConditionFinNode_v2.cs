using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenVingNoObjConditionFinNodeAction(ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 item);

    public class ATNSubjWillFToHaveBeenVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, InitATNSubjWillFToHaveBeenVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_Ving_No_Obj_Condition_Fin;

        public ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

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

