using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenV3ObjConditionFinNodeAction(ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenV3ObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenV3ObjConditionFinNodeFactory_v2(ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_V3_Obj_Condition_Fin;

        public ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenV3ObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenV3ObjConditionFinNodeAction mInitAction;

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

