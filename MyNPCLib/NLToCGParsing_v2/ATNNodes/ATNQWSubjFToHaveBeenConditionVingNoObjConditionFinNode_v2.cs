using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction(ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin;

        public ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

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

