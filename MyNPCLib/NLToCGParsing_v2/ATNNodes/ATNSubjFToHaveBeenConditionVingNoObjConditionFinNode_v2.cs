using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction(ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 item);

    public class ATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, InitATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin;

        public ATNSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

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

