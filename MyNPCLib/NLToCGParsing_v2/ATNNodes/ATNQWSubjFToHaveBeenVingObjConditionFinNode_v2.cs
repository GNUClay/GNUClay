using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenVingObjConditionFinNodeAction(ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Ving_Obj_Condition_Fin;

        public ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

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

