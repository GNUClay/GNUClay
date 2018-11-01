using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeAction(ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin;

        public ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

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

