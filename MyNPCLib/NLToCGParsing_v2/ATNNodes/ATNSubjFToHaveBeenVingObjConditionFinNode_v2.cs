using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenVingObjConditionFinNodeAction(ATNSubjFToHaveBeenVingObjConditionFinNode_v2 item);

    public class ATNSubjFToHaveBeenVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveBeenVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, InitATNSubjFToHaveBeenVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Ving_Obj_Condition_Fin;

        public ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

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

