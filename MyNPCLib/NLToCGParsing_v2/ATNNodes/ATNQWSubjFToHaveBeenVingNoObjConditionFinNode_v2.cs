using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenVingNoObjConditionFinNodeAction(ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Ving_No_Obj_Condition_Fin;

        public ATNQWSubjFToHaveBeenVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenVingNoObjConditionFinNodeAction mInitAction;

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

