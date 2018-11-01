using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeV3NoObjConditionFinNodeAction(ATNQWSubjFToBeV3NoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeV3NoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeV3NoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeV3NoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_V3_No_Obj_Condition_Fin;

        public ATNQWSubjFToBeV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeV3NoObjConditionFinNodeAction mInitAction;

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

