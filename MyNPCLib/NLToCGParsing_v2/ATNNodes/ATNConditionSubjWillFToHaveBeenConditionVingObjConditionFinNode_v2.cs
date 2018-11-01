using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeAction(ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

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

