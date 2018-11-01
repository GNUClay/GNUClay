using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeAction(ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Condition_V3_Obj_Condition_Fin;

        public ATNConditionSubjWillFToHaveBeenConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenConditionV3ObjConditionFinNodeAction mInitAction;

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

