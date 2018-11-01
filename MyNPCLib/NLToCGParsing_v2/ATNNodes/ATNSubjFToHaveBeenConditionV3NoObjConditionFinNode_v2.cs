using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction(ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 item);

    public class ATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeFactory_v2(ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 sameNode, InitATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Condition_V3_No_Obj_Condition_Fin;

        public ATNSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction mInitAction;

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

