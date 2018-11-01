using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenVingObjConditionFinNodeAction(ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2 item);

    public class ATNSubjFToHaveNotBeenVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenVingObjConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenVingObjConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2 sameNode, InitATNSubjFToHaveNotBeenVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_Ving_Obj_Condition_Fin;

        public ATNSubjFToHaveNotBeenVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenVingObjConditionFinNodeAction mInitAction;

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

