using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction(ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_Been_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotBeenConditionVingObjConditionFinNodeAction mInitAction;

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

