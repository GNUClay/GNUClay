using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenV3NoObjConditionFinNodeAction(ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2 item);

    public class ATNSubjWillFToHaveBeenV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenV3NoObjConditionFinNodeFactory_v2(ATNSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenV3NoObjConditionFinNodeFactory_v2(ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2 sameNode, InitATNSubjWillFToHaveBeenV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_V3_No_Obj_Condition_Fin;

        public ATNSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenV3NoObjConditionFinNodeAction mInitAction;

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

