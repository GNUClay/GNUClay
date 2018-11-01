using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction(ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 item);

    public class ATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 sameNode, InitATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_Condition_Ving_Obj_Condition_Fin;

        public ATNSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction mInitAction;

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

