using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjConditionVerbNoObjConditionFinNodeAction(ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNFToDoSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNFToDoSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNFToDoSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNFToDoSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNFToDoSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

