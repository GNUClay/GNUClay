using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenV3NoObjConditionFinNodeAction(ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenV3NoObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenV3NoObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_V3_No_Obj_Condition_Fin;

        public ATNQWSubjFToHaveBeenV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenV3NoObjConditionFinNodeAction mInitAction;

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

