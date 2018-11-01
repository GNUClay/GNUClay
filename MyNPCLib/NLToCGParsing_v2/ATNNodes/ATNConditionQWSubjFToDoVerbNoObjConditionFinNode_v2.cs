using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoVerbNoObjConditionFinNodeAction(ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToDoVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToDoVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Verb_No_Obj_Condition_Fin;

        public ATNConditionQWSubjFToDoVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoVerbNoObjConditionFinNodeAction mInitAction;

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

