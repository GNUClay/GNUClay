using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeAction(ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Condition_Ving_Obj_Condition_Fin;

        public ATNQWSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

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

