using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeAction(ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Ving_No_Obj_Condition_Fin;

        public ATNConditionSubjFToHaveBeenVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

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

