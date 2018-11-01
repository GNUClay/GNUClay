using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveV3NoObjConditionFinNodeAction(ATNWillSubjFToHaveV3NoObjConditionFinNode_v2 item);

    public class ATNWillSubjFToHaveV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveV3NoObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveV3NoObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjFToHaveV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveV3NoObjConditionFinNode_v2 sameNode, InitATNWillSubjFToHaveV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_V3_No_Obj_Condition_Fin;

        public ATNWillSubjFToHaveV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveV3NoObjConditionFinNodeAction mInitAction;

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

