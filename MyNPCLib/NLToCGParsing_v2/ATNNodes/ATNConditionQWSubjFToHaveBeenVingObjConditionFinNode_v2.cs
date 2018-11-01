using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeAction(ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveBeenVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Been_Ving_Obj_Condition_Fin;

        public ATNConditionQWSubjFToHaveBeenVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveBeenVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveBeenVingObjConditionFinNodeAction mInitAction;

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

