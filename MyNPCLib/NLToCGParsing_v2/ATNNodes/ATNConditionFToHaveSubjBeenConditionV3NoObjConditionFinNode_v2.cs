using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeAction(ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Condition_V3_No_Obj_Condition_Fin;

        public ATNConditionFToHaveSubjBeenConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenConditionV3NoObjConditionFinNodeAction mInitAction;

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

