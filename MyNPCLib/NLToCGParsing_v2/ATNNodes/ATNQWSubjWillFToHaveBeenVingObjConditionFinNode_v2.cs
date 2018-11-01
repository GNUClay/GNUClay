using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenVingObjConditionFinNodeAction(ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Ving_Obj_Condition_Fin;

        public ATNQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenVingObjConditionFinNodeAction mInitAction;

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

