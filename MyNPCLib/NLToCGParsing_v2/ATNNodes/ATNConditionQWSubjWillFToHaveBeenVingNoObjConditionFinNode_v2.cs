using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeAction(ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Been_Ving_No_Obj_Condition_Fin;

        public ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

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

