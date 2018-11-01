using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction(ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_Condition_Ving_Obj_Condition_Fin;

        public ATNSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenConditionVingObjConditionFinNodeAction mInitAction;

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

