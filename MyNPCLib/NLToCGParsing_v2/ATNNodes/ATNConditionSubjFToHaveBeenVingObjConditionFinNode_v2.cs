using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenVingObjConditionFinNodeAction(ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToHaveBeenVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToHaveBeenVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Ving_Obj_Condition_Fin;

        public ATNConditionSubjFToHaveBeenVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

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

