using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveV3NoObjConditionFinNodeAction(ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveV3NoObjConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveV3NoObjConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_V3_No_Obj_Condition_Fin;

        public ATNConditionWillSubjFToHaveV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveV3NoObjConditionFinNodeAction mInitAction;

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

