using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction(ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Been_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

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

