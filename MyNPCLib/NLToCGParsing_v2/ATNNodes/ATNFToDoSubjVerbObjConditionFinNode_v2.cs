using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjVerbObjConditionFinNodeAction(ATNFToDoSubjVerbObjConditionFinNode_v2 item);

    public class ATNFToDoSubjVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjVerbObjConditionFinNodeFactory_v2(ATNFToDoSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjVerbObjConditionFinNodeFactory_v2(ATNFToDoSubjVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjVerbObjTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoSubjVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbObjConditionFinNode_v2 sameNode, InitATNFToDoSubjVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Verb_Obj_Condition_Fin;

        public ATNFToDoSubjVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjVerbObjConditionFinNode_v2 mSameNode;
        private InitATNFToDoSubjVerbObjConditionFinNodeAction mInitAction;

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

