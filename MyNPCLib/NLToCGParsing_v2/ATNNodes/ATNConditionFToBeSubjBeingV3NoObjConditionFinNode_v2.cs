using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjBeingV3NoObjConditionFinNodeAction(ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjBeingV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjBeingV3NoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjBeingV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjBeingV3NoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjBeingV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjBeingV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjBeingV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjBeingV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Being_V3_No_Obj_Condition_Fin;

        public ATNConditionFToBeSubjBeingV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjBeingV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjBeingV3NoObjConditionFinNodeAction mInitAction;

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

