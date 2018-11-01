using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction(ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Condition_V3_No_Obj_Condition_Fin;

        public ATNWillSubjFToHaveBeenConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenConditionV3NoObjConditionFinNodeAction mInitAction;

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

