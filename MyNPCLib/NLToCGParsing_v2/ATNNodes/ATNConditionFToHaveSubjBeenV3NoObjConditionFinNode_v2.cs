using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeAction(ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_V3_No_Obj_Condition_Fin;

        public ATNConditionFToHaveSubjBeenV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenV3NoObjConditionFinNodeAction mInitAction;

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

