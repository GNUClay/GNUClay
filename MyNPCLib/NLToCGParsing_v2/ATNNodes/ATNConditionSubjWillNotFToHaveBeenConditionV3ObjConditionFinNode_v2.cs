using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeAction(ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveBeenConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Been_Condition_V3_Obj_Condition_Fin;

        public ATNConditionSubjWillNotFToHaveBeenConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveBeenConditionV3ObjConditionFinNodeAction mInitAction;

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

