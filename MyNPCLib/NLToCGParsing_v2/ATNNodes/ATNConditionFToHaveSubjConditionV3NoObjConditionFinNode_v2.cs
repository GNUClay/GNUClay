using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeAction(ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2 item);

    public class ATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2 sameNode, InitATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Condition_V3_No_Obj_Condition_Fin;

        public ATNConditionFToHaveSubjConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjConditionV3NoObjConditionFinNodeAction mInitAction;

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

