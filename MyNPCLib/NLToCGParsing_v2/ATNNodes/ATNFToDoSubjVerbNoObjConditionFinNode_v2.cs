using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjVerbNoObjConditionFinNodeAction(ATNFToDoSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNFToDoSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjVerbNoObjConditionFinNodeFactory_v2(ATNFToDoSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjVerbNoObjConditionFinNodeFactory_v2(ATNFToDoSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNFToDoSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Verb_No_Obj_Condition_Fin;

        public ATNFToDoSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNFToDoSubjVerbNoObjConditionFinNodeAction mInitAction;

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

