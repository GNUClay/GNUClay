using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjVerbNoObjConditionFinNodeAction(ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionFToDoSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionFToDoSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionFToDoSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Verb_No_Obj_Condition_Fin;

        public ATNConditionFToDoSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToDoSubjVerbNoObjConditionFinNodeAction mInitAction;

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

