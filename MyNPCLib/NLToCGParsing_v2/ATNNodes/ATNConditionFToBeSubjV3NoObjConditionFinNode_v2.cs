using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjV3NoObjConditionFinNodeAction(ATNConditionFToBeSubjV3NoObjConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjV3NoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjV3NoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjV3NoObjConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_V3_No_Obj_Condition_Fin;

        public ATNConditionFToBeSubjV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjV3NoObjConditionFinNodeAction mInitAction;

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

