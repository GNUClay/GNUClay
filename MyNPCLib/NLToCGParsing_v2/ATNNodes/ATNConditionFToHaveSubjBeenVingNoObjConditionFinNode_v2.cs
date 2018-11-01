using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeAction(ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Ving_No_Obj_Condition_Fin;

        public ATNConditionFToHaveSubjBeenVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenVingNoObjConditionFinNodeAction mInitAction;

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

