using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction(ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin;

        public ATNWillSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenConditionVingNoObjConditionFinNodeAction mInitAction;

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

