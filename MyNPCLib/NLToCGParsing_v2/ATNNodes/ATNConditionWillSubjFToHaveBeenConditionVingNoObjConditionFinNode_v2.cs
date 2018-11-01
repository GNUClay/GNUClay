using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction(ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin;

        public ATNConditionWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

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

